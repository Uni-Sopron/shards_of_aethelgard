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

            TestEnemy = new Enemy("Binary Wolf", 50, 10, "Beast");
        }

        public string PlayCombatRound()
        {
            if (CurrentPlayer == null || TestEnemy == null)
                return "Error: No active game!";

            if (CurrentPlayer.IsDead() || TestEnemy.IsDead())
                return "The combat is already over!";

            string combatLog = "";

            // --- PLAYER'S TURN ---
            int playerDamage = CurrentPlayer.Attack(TestEnemy);
            combatLog += $"{CurrentPlayer.Name} attacks! Damage: {playerDamage}. Wolf HP: {TestEnemy.Health}\r\n";

            if (TestEnemy.IsDead())
            {
                combatLog += "Victory! The Binary Wolf has been defeated.";
                CurrentPlayer.GainXP(50);
                return combatLog;
            }

            // --- ENEMY'S TURN ---
            int enemyDamage = TestEnemy.AutoAttack(CurrentPlayer);
            combatLog += $"{TestEnemy.Name} retaliates! Damage: {enemyDamage}. Your HP: {CurrentPlayer.Health}\r\n";

            if (CurrentPlayer.IsDead())
            {
                combatLog += "Defeat! The darkness consumes you...";
            }

            return combatLog;
        }
    }
}