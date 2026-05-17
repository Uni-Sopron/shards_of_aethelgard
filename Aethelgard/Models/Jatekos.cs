using System;

namespace Aethelgard.Models
{
    public class Player : Character
    {
        public int Experience { get; set; }
        public int Level { get; set; }
        public ClassType HeroClass { get; set; }
        public Player() { }

        public Player(string name, ClassType heroClass) : base(name, 100, 20)
        {
            HeroClass = heroClass;
            Level = 1;
            Experience = 0;

            if (heroClass == ClassType.RuneWarrior) { Health = 150; AttackPower = 25; }
            else if (heroClass == ClassType.NumberMage) { Health = 90; AttackPower = 40; }
            else if (heroClass == ClassType.ShadowAlgorithm) { Health = 80; AttackPower = 30; }
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 20;
            Health = MaxHealth;
            AttackPower += 5;
            Console.WriteLine($"{Name} leveled up to level {Level}!");
        }

        public void GainXP(int points)
        {
            Experience += points;
            if (Experience >= Level * 100)
            {
                LevelUp();
            }
        }

        public int Attack(Character target)
        {
            target.Health -= AttackPower;
            return AttackPower;
        }
    }
}