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
            MaxMana += 15;
            Mana = MaxMana;
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
        public string UseSpecialAbility(Enemy target)
        {
            if (Mana < 20) return "Nincs elég Manád a képességhez!";

            Mana -= 20;
            string result = "";

            switch (HeroClass)
            {
                case ClassType.RuneWarrior:
                    int heavyDmg = AttackPower * 2;
                    target.Health -= heavyDmg;
                    result = $"[KÉPESSÉG] Rúnacsapás! Hatalmasat sóztál oda: {heavyDmg} sebzés!";
                    break;

                case ClassType.NumberMage:
                    int magicDmg = AttackPower + 30;
                    target.Health -= magicDmg;
                    result = $"[KÉPESSÉG] Osztás Nullával! A valóság meghasad: {magicDmg} sebzés!";
                    break;

                case ClassType.ShadowAlgorithm:
                    int drainDmg = AttackPower + 10;
                    target.Health -= drainDmg;

                    Health += drainDmg;
                    if (Health > MaxHealth) Health = MaxHealth;

                    result = $"[KÉPESSÉG] Adatszivárgás! Megcsapoltad az ellenfelet, és gyógyultál {drainDmg} HP-t!";
                    break;
            }

            return result;
        }
    }
}