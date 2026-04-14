class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }
    public void Attack(Character target)
    {
        target.Health -= AttackPower;
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
    }
}