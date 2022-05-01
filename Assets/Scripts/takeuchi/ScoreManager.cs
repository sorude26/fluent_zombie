using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public static int Score { get; private set; }
    public static void AddScore(int score)
    {
        Score += score;
    }
    public static void ReSetScore()
    {
        Score = 0;
    }
}
