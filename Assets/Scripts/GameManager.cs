using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private GameTimer _gameTimer = default;
    [SerializeField]
    private EnemyGenerator _generator = default;
    [SerializeField]
    GameObject _gameOver = default;
    [SerializeField]
    GameObject _gameClear = default;
    private IEnumerator Start()
    {
        yield return null;
        StartGame();
    }
    public void StartGame()
    {
        _gameTimer.StartTimer();
        _generator.StartGenerator();
    }
}
