using System.ComponentModel.DataAnnotations;

public abstract class Character
{
    [Key]
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int AttackPower { get; set; }

    public Character() { }

    public Character(string name, int health, int attackPower)
    {
        Name = name;
        MaxHealth = health;
        Health = health;
        AttackPower = attackPower;
    }

    public bool IsDead() => Health <= 0;
}