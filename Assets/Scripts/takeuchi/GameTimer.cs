using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private const int SEXAGESIMAL_TIME = 60;
    /// <summary> タイマー停止時のイベント </summary>
    public event Action DelTimerStop = default;
    [Tooltip("終了時間")]
    [SerializeField]
    private int _maxCountTime = 60;
    /// <summary> 現時間 </summary>
    private float _timer = default;
    /// <summary> 停止フラグ </summary>
    private bool _isStart = false;

    /// <summary> 現時間 </summary>
    public float CurrentTimer { get => _timer; }
    /// <summary> 現時刻の文字列 </summary>
    public string CurrentTimeText
    {
        get
        {
            int min = (int)_timer / SEXAGESIMAL_TIME;
            int second = (int)_timer % SEXAGESIMAL_TIME;
            return min + ":" + second;
        }
    }
    private IEnumerator Timer()
    {
        while (_timer > 0)
        {
            if (!_isStart)
            {
                break;
            }
            _timer -= Time.deltaTime;
            yield return null;
        }
        DelTimerStop?.Invoke();
        _isStart = false;
    }
    /// <summary>
    /// タイマースタート
    /// </summary>
    public void StartTimer()
    {
        if (_isStart)
        {
            return;
        }
        _isStart = true;
        _timer = _maxCountTime;
        StartCoroutine(Timer());
    }
    /// <summary>
    /// タイマーストップ
    /// </summary>
    public void StopTimer()
    {
        _isStart = false;
    }
}
