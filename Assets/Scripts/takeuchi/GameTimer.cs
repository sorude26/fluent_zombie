using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private const int SEXAGESIMAL_TIME = 60;
    /// <summary> �^�C�}�[��~���̃C�x���g </summary>
    public event Action DelTimerStop = default;
    [Tooltip("�I������")]
    [SerializeField]
    private int _maxCountTime = 60;
    /// <summary> ������ </summary>
    private float _timer = default;
    /// <summary> ��~�t���O </summary>
    private bool _isStart = false;

    /// <summary> ������ </summary>
    public float CurrentTimer { get => _timer; }
    /// <summary> �������̕����� </summary>
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
    /// �^�C�}�[�X�^�[�g
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
    /// �^�C�}�[�X�g�b�v
    /// </summary>
    public void StopTimer()
    {
        _isStart = false;
    }
}
