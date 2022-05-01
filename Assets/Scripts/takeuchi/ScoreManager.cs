using System;

public class ScoreManager
{
    private static int score = default;
    public static int Score 
    {
        get 
        { 
            return score;
        }
        private set 
        {
            score = value;
            DelUpdateScore?.Invoke();
        }
    }
    public static event Action DelUpdateScore;
    public static void AddScore(int score = 1)
    {
        Score += score;
    }
    public static void ReSetScore()
    {
        Score = 0;
    }
}
