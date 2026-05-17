using System;
using System.Linq;
using Aethelgard.Models;
using Microsoft.EntityFrameworkCore;

namespace Aethelgard.Controllers
{
    public class GameManager
    {
        public Player CurrentPlayer { get; private set; }
        public Enemy TestEnemy { get; private set; }
        public Puzzle CurrentPuzzle { get; private set; }

        public GameManager()
        {
            using (var db = new GameDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        // Új ellenfél generálása - Most már csak akkor hívódik meg, ha a játékos kéri
        public void SpawnNextEnemy()
        {
            if (CurrentPlayer == null) return;

            Random rnd = new Random();
            int veletlenSzam = rnd.Next(1, 4);

            // A szörnyek statisztikái a játékos szintjével skálázódnak
            int enemyHp = 40 + (CurrentPlayer.Level * 15);
            int enemyDmg = 5 + (CurrentPlayer.Level * 5);

            switch (veletlenSzam)
            {
                case 1:
                    TestEnemy = new Enemy("Bináris Farkas", enemyHp, enemyDmg, "Állat");
                    break;
                case 2:
                    TestEnemy = new Enemy("Logikai Lidérc", enemyHp - 10, enemyDmg + 5, "Szellem");
                    break;
                default:
                    TestEnemy = new Enemy("Zéró Gólem", enemyHp + 30, enemyDmg - 2, "Gépezet");
                    break;
            }
        }
        public void GeneratePuzzle()
        {
            // Ide később be lehet kötni egy adatbázist, most a prototípushoz véletlenszerűen adunk egyet
            Random rnd = new Random();
            int type = rnd.Next(1, 4);

            if (type == 1)
                CurrentPuzzle = new Puzzle("Mennyi 150 és 2.5 szorzata?", 375, 100);
            else if (type == 2)
                CurrentPuzzle = new Puzzle("Mi a 4096 négyzetgyöke?", 64, 150);
            else
                CurrentPuzzle = new Puzzle("Ha 5 gép 5 perc alatt 5 terméket gyárt, hány perc alatt gyárt 100 gép 100 terméket?", 5, 200);
        }

        public string SolvePuzzle(double playerGuess)
        {
            if (CurrentPuzzle == null) return "Nincs aktív rejtvény!";

            double exactAnswer = CurrentPuzzle.CorrectAnswer;

            double marginOfError = Math.Abs(exactAnswer * 0.01);

            double difference = Math.Abs(playerGuess - exactAnswer);

            string log = $"[REJTVÉNY] Válaszod: {playerGuess}. A helyes válasz: {exactAnswer}.\r\n";

            if (difference == 0)
            {
                CurrentPlayer.GainXP(CurrentPuzzle.MaxXpReward);
                log += $"TÖKÉLETES! Megkaptad a maximális {CurrentPuzzle.MaxXpReward} XP-t.\r\n";
            }
            else if (difference <= marginOfError)
            {
                int halfXp = CurrentPuzzle.MaxXpReward / 2;
                CurrentPlayer.GainXP(halfXp);
                log += $"MAJDNEM PONTOS! Még a hibahatáron belül vagy. Kaptál {halfXp} XP-t.\r\n";
            }
            else
            {
                log += "HELYTELEN VÁLASZ! Nem járt érte tapasztalati pont.\r\n";
            }

            CurrentPuzzle = null;
            return log;
        }

        public void StartNewGame(string name, ClassType heroClass)
        {
            CurrentPlayer = new Player(name, heroClass);
            // Az első harcot elindíthatjuk automatikusan, vagy ezt is rábízhatjuk a UI-ra
            SpawnNextEnemy();
        }

        public string PlayCombatRound()
        {
            if (CurrentPlayer == null || TestEnemy == null) return "Nincs ellenfél, ne hadonássz!";
            if (CurrentPlayer.IsDead() || TestEnemy.IsDead()) return "A harc már véget ért!";

            string combatLog = "";

            // Játékos támadása
            int playerDamage = CurrentPlayer.Attack(TestEnemy);
            combatLog += $"{CurrentPlayer.Name} támad! Sebzés: {playerDamage}. {TestEnemy.Name} HP: {TestEnemy.Health}\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += $"Győzelem! A(z) {TestEnemy.Name} elpusztult.\r\n";
                CurrentPlayer.GainXP(50);
                combatLog += $"[+] Kaptál 50 Tapasztalatot! Jelenlegi szinted: {CurrentPlayer.Level}.\r\n";
                return combatLog;
            }

            // Ellenfél visszatámadása
            int enemyDamage = TestEnemy.AutoAttack(CurrentPlayer);
            combatLog += $"{TestEnemy.Name} visszatámad! Sebzés: {enemyDamage}. Te HP-d: {CurrentPlayer.Health}\r\n";

            if (CurrentPlayer.IsDead()) combatLog += "Vereség! A sötétség elnyelt...";

            return combatLog;
        }
        public string PlaySpecialRound()
        {
            if (CurrentPlayer == null || TestEnemy == null) return "Nincs ellenfél, ne hadonássz!";
            if (CurrentPlayer.IsDead() || TestEnemy.IsDead()) return "A harc már véget ért!";

            if (CurrentPlayer.Mana < 20) return "Nincs elég Manád! Használj sima támadást.";

            string combatLog = "";

            combatLog += CurrentPlayer.UseSpecialAbility(TestEnemy) + "\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += $"Győzelem! A(z) {TestEnemy.Name} elpusztult.\r\n";
                CurrentPlayer.GainXP(50);
                return combatLog;
            }

            int enemyDamage = TestEnemy.AutoAttack(CurrentPlayer);
            combatLog += $"{TestEnemy.Name} visszatámad! Sebzés: {enemyDamage}. Te HP-d: {CurrentPlayer.Health}\r\n";

            if (CurrentPlayer.IsDead()) combatLog += "Vereség! A sötétség elnyelt...";

            return combatLog;
        }

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
                    existingPlayer.MaxHealth = CurrentPlayer.MaxHealth;
                    existingPlayer.Mana = CurrentPlayer.Mana;
                    existingPlayer.MaxMana = CurrentPlayer.MaxMana;
                    existingPlayer.AttackPower = CurrentPlayer.AttackPower;
                    db.Entry(existingPlayer).State = EntityState.Modified;
                }
                else
                {
                    db.Players.Add(CurrentPlayer);
                }
                db.SaveChanges();
            }
        }

        public bool LoadGame()
        {
            using (var db = new GameDbContext())
            {
                var loadedPlayer = db.Players.FirstOrDefault();

                if (loadedPlayer != null)
                {
                    CurrentPlayer = loadedPlayer;
                    TestEnemy = null;
                    return true;
                }
            }
            return false;
        }
    }
}