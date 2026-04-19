using System;
using Aethelgard.Models;

namespace Aethelgard.Controllers
{
    public class GameManager
    {
        public Player CurrentPlayer { get; private set; }
        public Enemy TestEnemy { get; private set; }

        public void StartNewGame(string name, ClassType heroClass)
        {
            CurrentPlayer = new Player(name, heroClass);

            TestEnemy = new Enemy("Bináris Farkas", 50, 10, "Állat");
        }

        public string PlayCombatRound()
        {
            if (CurrentPlayer == null || TestEnemy == null)
                return "Nincs még harc!";

            if (CurrentPlayer.IsDead() || TestEnemy.IsDead())
                return "A csatának vége!";

            string combatLog = "";

            // --- PLAYER'S TURN ---
            int playerDamage = CurrentPlayer.Attack(TestEnemy);
            combatLog += $"{CurrentPlayer.Name} támad! Sebzés: {playerDamage}. Ellenség HP-ja: {TestEnemy.Health}\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += "Győzelem! Az ellenség elhullott.";
                CurrentPlayer.GainXP(50);
                return combatLog;
            }

            // --- ENEMY'S TURN ---
            int enemyDamage = TestEnemy.AutoAttack(CurrentPlayer);
            combatLog += $"{TestEnemy.Name} visszatámad! Sebzés: {enemyDamage}. A te HP-d: {CurrentPlayer.Health}\r\n";

            if (CurrentPlayer.IsDead())
            {
                combatLog += "Vereség! A Sötétség elnyelt!";
            }

            return combatLog;
        }
    }
}