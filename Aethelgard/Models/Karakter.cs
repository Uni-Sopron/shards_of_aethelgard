using System.ComponentModel.DataAnnotations;

public abstract class Character
{
    [Key]
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int AttackPower { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }

    public Character() { }

    public Character(string name, int health, int attackPower)
    {
        Name = name;
        MaxHealth = health;
        Health = health;
        MaxMana = 50;
        Mana = 50;
        AttackPower = attackPower;
    }

    public bool IsDead() => Health <= 0;
}