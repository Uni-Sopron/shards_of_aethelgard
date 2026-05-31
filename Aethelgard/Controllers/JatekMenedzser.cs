using System;
using System.Linq;
using System.Collections.Generic;
using Aethelgard.Models;
using Microsoft.EntityFrameworkCore;

namespace Aethelgard.Controllers
{
    public class GameManager
    {
        public Player CurrentPlayer { get; private set; }
        public Enemy TestEnemy { get; private set; }
        public Puzzle CurrentPuzzle { get; private set; }

        private List<Puzzle> _puzzleList = new List<Puzzle>
        {
            new Puzzle("Mennyi 12 és 18 legkisebb közös többszöröse?", 36, 100),
            new Puzzle("Ha egy rúnakő 2.5 kg, mennyi 4 rúnakő súlya?", 10, 50),
            new Puzzle("Egy háromszög két szöge 45 és 90 fokos. Hány fokos a harmadik?", 45, 50),
            new Puzzle("A Világfa 3 főágán áganként 7 holló ül. Hány holló figyeli a káoszt?", 21, 60),
            new Puzzle("A Zéró Entitás ereje percenként duplázódik. Ha most 5 egység, mennyi lesz 3 perc múlva?", 40, 120),
            new Puzzle("A Kódexőrzők pajzsa egy szabályos hatszög. Hány átlója van?", 9, 150),
            new Puzzle("Egy varázslat manaköltsége 50. Ha a botod 20%-kal csökkenti ezt, mennyi manát használsz?", 40, 80),
            new Puzzle("Három Kiszámíthatatlan szörny HP-ja 15, 25 és 50. Mennyi az átlagos életerejük?", 30, 90),
            new Puzzle("Egy 8 méter magas rúnatorony árnyéka 6 méter. Milyen messze van a torony csúcsa az árnyék végétől?", 10, 150),
            new Puzzle("Ha egy nap Aethelgardban 30 órából áll, hányszor mutatja az óra a 12:00-t egy nap alatt?", 2, 50),
            new Puzzle("A Nagy Kódex 120 oldalas. A káosz megsemmisítette a negyedét, majd a maradék harmadát. Hány oldal maradt?", 60, 120),
            new Puzzle("Folytasd a rúnasorozatot: 2, 5, 10, 17, 26... Mi a következő szám?", 37, 200),
            new Puzzle("Egy ládán ez a kód áll: 5 faktoriálisa (5!). Mi a jelszó?", 120, 150),
            new Puzzle("Egy pók 10 méter mély gödörből mászik kifelé. Nappal 3 métert mászik fel, éjjel 2 métert csúszik vissza. Hányadik napon ér fel?", 8, 200),
            new Puzzle("Mennyi a 2 a 10-en fele?", 512, 100),
            new Puzzle("Két dobókockával dobunk. Hányféleképpen dobhatunk pontosan 7-et?", 6, 180),
            new Puzzle("Hány darab prím szám van 1 és 10 között?", 4, 100),
            new Puzzle("Egy mágikus kör sugara 10 méter. Mennyi a területe, ha Pi értékét 3.14-nek vesszük?", 314, 120),
            new Puzzle("Oldd meg az ősi egyenletet: 3x - 15 = 45. Mennyi az x?", 20, 100),
            new Puzzle("Egy négyzet alapú piramis alapéle 10, magassága 12. Mennyi a térfogata?", 400, 150),
            new Puzzle("Melyik szám négyzete és köbe egyenlő önmagával (a 0-n kívül)?", 1, 80),
            new Puzzle("Ha az 'ALMA' szó értéke 27, mennyi a 'BABA' szó értéke a magyar ábécé sorszámai alapján?", 6, 200),
            new Puzzle("Egy 100 fős seregben 70 harcosnak van kardja, 50-nek pajzsa. Minimum hány harcosnak van kardja ÉS pajzsa is?", 20, 250),
            new Puzzle("Mennyi 1000-nek a 15%-a?", 150, 50),
            new Puzzle("A Kiszámíthatatlanok 4 óra alatt tesznek meg 60 mérföldet. Mennyi a sebességük?", 15, 80)
        };

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
            Random rnd = new Random();
            int index = rnd.Next(_puzzleList.Count);
            CurrentPuzzle = _puzzleList[index];
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
            SpawnNextEnemy();
        }

        public string PlayCombatRound()
        {
            if (CurrentPlayer == null || TestEnemy == null) return "Nincs ellenfél, ne hadonássz!";
            if (CurrentPlayer.IsDead() || TestEnemy.IsDead()) return "A harc már véget ért!";

            string combatLog = "";

            int playerDamage = CurrentPlayer.Attack(TestEnemy);
            combatLog += $"{CurrentPlayer.Name} támad! Sebzés: {playerDamage}. {TestEnemy.Name} HP: {TestEnemy.Health}\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += $"Győzelem! A(z) {TestEnemy.Name} elpusztult.\r\n";
                int rewardXp = (TestEnemy.MaxHealth / 3) + TestEnemy.AttackPower;
                CurrentPlayer.GainXP(rewardXp);
                combatLog += $"[+] Kaptál {rewardXp} Tapasztalatot! Jelenlegi szinted: {CurrentPlayer.Level}.\r\n";
                return combatLog;
            }

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

            CurrentPlayer.Mana -= 20;
            string combatLog = "";
            int specialDamage = 0;
            Random rnd = new Random();

            // KASZTSPECIFIKUS KÉPESSÉGEK LOGIKÁJA
            switch (CurrentPlayer.HeroClass)
            {
                case ClassType.RuneWarrior:
                    specialDamage = CurrentPlayer.AttackPower * 2;
                    TestEnemy.Health -= specialDamage;
                    int healAmount = specialDamage / 2;
                    CurrentPlayer.Health += healAmount;
                    if (CurrentPlayer.Health > CurrentPlayer.MaxHealth) CurrentPlayer.Health = CurrentPlayer.MaxHealth;

                    combatLog += $"[Rúnaharcos] Vérszívó Csapás! Sebzés: {specialDamage}. Gyógyultál: {healAmount} HP.\r\n";
                    break;

                case ClassType.NumberMage:
                    double multiplier = rnd.NextDouble() * (4.0 - 1.5) + 1.5;
                    specialDamage = (int)(CurrentPlayer.AttackPower * multiplier);
                    TestEnemy.Health -= specialDamage;

                    combatLog += $"[Számmágus] Káosz Képlet! Instabil varázslat robbant: {specialDamage} sebzés!\r\n";
                    break;

                case ClassType.ShadowAlgorithm:
                    specialDamage = (int)(CurrentPlayer.AttackPower * 2.5);
                    TestEnemy.Health -= specialDamage;
                    combatLog += $"[Árnyék Algoritmus] Végzetes Rekurzió! Célpont megsebezve: {specialDamage}.\r\n";

                    if (rnd.Next(1, 101) <= 30)
                    {
                        CurrentPlayer.Mana += 10;
                        if (CurrentPlayer.Mana > CurrentPlayer.MaxMana) CurrentPlayer.Mana = CurrentPlayer.MaxMana;
                        combatLog += "* A rekurzió sikeres! Visszanyertél 10 Manát! *\r\n";
                    }
                    break;

                default:
                    specialDamage = CurrentPlayer.AttackPower * 2;
                    TestEnemy.Health -= specialDamage;
                    combatLog += $"Speciális támadás! Sebzés: {specialDamage}.\r\n";
                    break;
            }

            if (TestEnemy.IsDead())
            {
                combatLog += $"Győzelem! A(z) {TestEnemy.Name} elpusztult.\r\n";
                int rewardXp = (TestEnemy.MaxHealth / 3) + TestEnemy.AttackPower;
                CurrentPlayer.GainXP(rewardXp);
                combatLog += $"[+] Kaptál {rewardXp} Tapasztalatot! Jelenlegi szinted: {CurrentPlayer.Level}.\r\n";
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

        public bool LoadGame(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName)) return false;

            using (var db = new GameDbContext())
            {
                var loadedPlayer = db.Players.FirstOrDefault(p => p.Name == playerName);
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