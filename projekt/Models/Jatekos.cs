import Karakter from Models.Karakter;

class Player : Karakter.Character
{
    public int Score { get; set; }
    public int Level { get; set; }
    public Player(string name, int health, int score, int level) : base(name, health)
    {
        Score = score;
        Level = level;
    }
    public void LevelUp()
    {
        Level++;
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }
    public void AddScore(int points)
    {
        Score += points;
        Console.WriteLine($"{Name} gained {points} points! Total score: {Score}");
    }
}