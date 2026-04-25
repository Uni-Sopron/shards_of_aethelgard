using System;
using System.Linq;
using Aethelgard.Models;

namespace Aethelgard.Controllers
{
    public class GameManager
    {
        public Player CurrentPlayer { get; private set; }
        public Enemy TestEnemy { get; private set; }

        public GameManager()
        {
            using (var db = new GameDbContext())
            {
                db.Database.EnsureCreated();
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

            using (var db = new GameDbContext())
            {
                var existingPlayer = db.Players.Find(CurrentPlayer.Name);

                if (existingPlayer != null)
                {
                    existingPlayer.Level = CurrentPlayer.Level;
                    existingPlayer.Experience = CurrentPlayer.Experience;
                    existingPlayer.Health = CurrentPlayer.Health;
                    existingPlayer.AttackPower = CurrentPlayer.AttackPower;
                }
                else
                {
                    db.Players.Add(CurrentPlayer);
                }
                db.SaveChanges();
            }
        }

        // --- ADATBÁZIS BETÖLTÉS ---
        public bool LoadGame()
        {
            using (var db = new GameDbContext())
            {
                var loadedPlayer = db.Players.FirstOrDefault();

                if (loadedPlayer != null)
                {
                    CurrentPlayer = loadedPlayer;
                    SpawnNextEnemy();
                    return true;
                }
            }
            return false;
        }
    }
}