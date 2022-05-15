using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Perapera_Puroto
{
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
        [SerializeField]
        Text _scoreText;
        private bool _isGameOver = false;
        private void Awake()
        {
            Instance = this;
        }
        private IEnumerator Start()
        {
            yield return null;
            UpdateScore();
            _gameTimer.DelTimerStop += OnTimerStop;
            ScoreManager.DelUpdateScore += UpdateScore;
            StartGame();
        }
        private void OnTimerStop()
        {
            if (_isGameOver)
            {
                return;
            }
            GameClear();
        }
        private void UpdateScore()
        {
            _scoreText.text = "Score" + ScoreManager.Score;
        }
        private void GameClear()
        {
            _gameClear.SetActive(true);
        }
        public void StartGame()
        {
            _gameTimer.StartTimer();
            _generator.StartGenerator();
        }
        public void GameOver()
        {
            _isGameOver = true;
            _gameOver.SetActive(true);
            _gameTimer.StopTimer();
        }
    }
}