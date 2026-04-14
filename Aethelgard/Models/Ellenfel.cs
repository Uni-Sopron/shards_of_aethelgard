using System;

namespace Aethelgard.Models
{
    public class Enemy : Character
    {
        public string Type { get; set; }

        public Enemy(string name, int health, int attackPower, string type = "Monster") : base(name, health, attackPower)
        {
            Type = type;
        }

        public int AutoAttack(Character target)
        {
            target.Health -= AttackPower;
            return AttackPower;
        }
    }
}