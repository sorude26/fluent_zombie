using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/NoChangeCountTimer")]
public class NoChangeCountTimerMission : MissionConditions
{
    [SerializeField, Header("�Ώ�ID")]
    private int _targetID = default;
    [SerializeField, Header("�ڕW����")]
    private float _targetTime = default;
    private int _targetCount = default;
    private float _timer = -1f;
    public override bool ClearConditions()
    {
        if (_timer < 0)
        {
            if (GameData.Instance.CountData.ContainsKey(_targetID))
            {
                _targetCount = GameData.Instance.CountData[_targetID];
            }
            else
            {
                GameData.Instance.AddCount(_targetID, 0);
            }
            _timer = GameData.Instance.GameTime;
            return false;
        }
        if (_targetCount != GameData.Instance.CountData[_targetID])
        {
            _targetCount = GameData.Instance.CountData[_targetID];
            _timer = GameData.Instance.GameTime;
            return false;
        }
        if (GameData.Instance.GameTime - _timer >= _targetTime)
        {
            return true;
        }
        return false;
    }
}
