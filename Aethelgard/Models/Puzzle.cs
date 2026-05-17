namespace Aethelgard.Models
{
    public class Puzzle
    {
        public string Question { get; set; }
        public double CorrectAnswer { get; set; }
        public int MaxXpReward { get; set; }

        public Puzzle(string question, double correctAnswer, int maxXpReward)
        {
            Question = question;
            CorrectAnswer = correctAnswer;
            MaxXpReward = maxXpReward;
        }
    }
}