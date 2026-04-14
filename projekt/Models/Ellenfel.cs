import Karakter from Models.Karakter;

class Ellenfel : Karakter.Character
{
    public int Damage { get; set; }
    public string Type { get; set; }
    public Ellenfel(string name, int health, int damage, string type) : base(name, health)
    {
        Damage = damage;
        Type = type;
    }
    public void Attack()
    {
        Console.WriteLine($"{Name} attacks with {Damage} damage!");
    }
}   