using Aethelgard.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aethelgard.Tests
{
    [TestClass]
    public class CharacterLogicTests
    {
        [TestMethod]
        public void IsDead_ShouldReturnTrue_WhenHealthIsZeroOrBelow()
        {
            Enemy testEnemy = new Enemy("Teszt Farkas", 50, 10, "Állat");

            testEnemy.Health = -5;

            Assert.IsTrue(testEnemy.IsDead(), "A szörnynek halottnak kell lennie 0 vagy az alatti HP esetén.");
        }

        [TestMethod]
        public void LevelUp_ShouldIncreaseMaxHealth_And_FullyHeal()
        {
            Player testPlayer = new Player("Teszt Hős", ClassType.RuneWarrior);
            testPlayer.MaxHealth = 100;
            testPlayer.Health = 10;
            testPlayer.Level = 1;

            testPlayer.LevelUp();

            Assert.AreEqual(2, testPlayer.Level, "A szintnek 1-ről 2-re kell nőnie.");
            Assert.IsGreaterThan(100, testPlayer.MaxHealth, "A maximális életerőnek növekednie kell szintlépéskor.");
            Assert.AreEqual(testPlayer.MaxHealth, testPlayer.Health, "Szintlépéskor a karakternek teljesen fel kell gyógyulnia.");
        }
    }
}