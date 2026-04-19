using System;
using Microsoft.Data.Sqlite;
using Aethelgard.Models;

namespace Aethelgard.Controllers
{
    public class GameManager
    {
        public Player CurrentPlayer { get; private set; }
        public Enemy TestEnemy { get; private set; }

        private string connectionString = "Data Source=aethelgard_save.db";

        public GameManager()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS PlayerSaves (
                        Name TEXT PRIMARY KEY,
                        HeroClass TEXT,
                        Level INTEGER,
                        Experience INTEGER
                    );
                ";
                command.ExecuteNonQuery();
            }
        }

        public void SpawnNextEnemy()
        {
            if (CurrentPlayer == null) return;

            Random rnd = new Random();
            int veletlenSzam = rnd.Next(1, 4);

            // A szörnyek statisztikái a játékos SZINTJÉVEL skálázódnak!
            int enemyHp = 40 + (CurrentPlayer.Level * 15);
            int enemyDmg = 5 + (CurrentPlayer.Level * 5);

            if (veletlenSzam == 1)
                TestEnemy = new Enemy("Bináris Farkas", enemyHp, enemyDmg, "Állat");
            else if (veletlenSzam == 2)
                TestEnemy = new Enemy("Logikai Lidérc", enemyHp - 10, enemyDmg + 5, "Szellem");
            else
                TestEnemy = new Enemy("Zéró Gólem", enemyHp + 30, enemyDmg - 2, "Gépezet");
        }

        public void StartNewGame(string name, ClassType heroClass)
        {
            CurrentPlayer = new Player(name, heroClass);
            SpawnNextEnemy();
        }

        public string PlayCombatRound()
        {
            if (CurrentPlayer == null || TestEnemy == null) return "Hiba: Nincs aktív játék!";
            if (CurrentPlayer.IsDead() || TestEnemy.IsDead()) return "A harc már véget ért!";

            string combatLog = "";

            int playerDamage = CurrentPlayer.Attack(TestEnemy);
            combatLog += $"{CurrentPlayer.Name} támad! Sebzés: {playerDamage}. Farkas HP: {TestEnemy.Health}\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += $"Győzelem! A(z) {TestEnemy.Name} elpusztult.\r\n";
                CurrentPlayer.GainXP(50);
                combatLog += $"[+] Kaptál 50 Tapasztalatot! Jelenlegi szinted: {CurrentPlayer.Level}.\r\n";
                return combatLog;
            }

            int enemyDamage = TestEnemy.AutoAttack(CurrentPlayer);
            combatLog += $"{TestEnemy.Name} visszatámad! Sebzés: {enemyDamage}. Te HP-d: {CurrentPlayer.Health}\r\n";

            if (CurrentPlayer.IsDead()) combatLog += "Vereség! A sötétség elnyelt...";

            return combatLog;
        }

        // --- ADATBÁZIS MENTÉS ---
        public void SaveGame()
        {
            if (CurrentPlayer == null) return;

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"
                    INSERT OR REPLACE INTO PlayerSaves (Name, HeroClass, Level, Experience) 
                    VALUES ($name, $class, $level, $exp);
                ";

                command.Parameters.AddWithValue("$name", CurrentPlayer.Name);
                command.Parameters.AddWithValue("$class", CurrentPlayer.HeroClass.ToString());
                command.Parameters.AddWithValue("$level", CurrentPlayer.Level);
                command.Parameters.AddWithValue("$exp", CurrentPlayer.Experience);

                command.ExecuteNonQuery();
            }
        }

        // --- ADATBÁZIS BETÖLTÉS ---
        public bool LoadGame()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT Name, HeroClass, Level, Experience FROM PlayerSaves LIMIT 1;";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString(0);
                        ClassType heroClass = (ClassType)Enum.Parse(typeof(ClassType), reader.GetString(1));
                        int level = reader.GetInt32(2);
                        int exp = reader.GetInt32(3);

                        CurrentPlayer = new Player(name, heroClass);
                        CurrentPlayer.Level = level;
                        CurrentPlayer.Experience = exp;

                        SpawnNextEnemy();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}