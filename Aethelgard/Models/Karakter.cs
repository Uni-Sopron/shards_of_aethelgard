using System.ComponentModel.DataAnnotations;

namespace Aethelgard.Models
{
    public abstract class Character
    {
        [Key]
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Character() { }

        public Character(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public bool IsDead() => Health <= 0;
    }
}