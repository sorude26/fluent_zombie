using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private const int SEXAGESIMAL_TIME = 60;
    private const int ONE_SECOND = 1;
    private const int CARRY_NUMBER = 10;
    /// <summary> �^�C�}�[��~���̃C�x���g </summary>
    public event Action DelTimerStop;
    [Tooltip("�I������")]
    [SerializeField]
    private int _maxCountTime = 60;
    [SerializeField]
    private Text _timerText = default;
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
            string secondText;
            if (second < CARRY_NUMBER)
            {
                secondText = "0" + second;
            }
            else
            {
                secondText = second.ToString();
            }
            return min + ":" + secondText;
        }
    }
    private IEnumerator Timer()
    {
        _timerText.text = CurrentTimeText;
        float timer = 0;
        while (_timer > 0)
        {
            if (!_isStart)
            {
                break;
            }
            timer += Time.deltaTime;
            if (timer >= ONE_SECOND)//1�b���ƂɃe�L�X�g�X�V����
            {
                timer = 0;
                _timerText.text = CurrentTimeText;
            }
            _timer -= Time.deltaTime;            
            yield return null;
        }
        DelTimerStop?.Invoke();
        DelTimerStop = null;
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
