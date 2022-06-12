using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBase : MonoBehaviour
{
    [SerializeField]
    protected MissionConditions[] _startConditions = null;
    [SerializeField]
    protected MissionConditions[] _clearConditions = null;
    [SerializeField]
    protected MissionReward[] _rewards = null;
    protected bool _isCanBeStarted = default;
    public bool IsCanBeStarted
    {
        get
        {
            if (_isCanBeStarted)
            {
                return true;
            }
            foreach (var condition in _startConditions)
            {
                if (!condition.ClearConditions())
                {
                    return false;
                }
            }
            _isCanBeStarted = true;
            return true;
        }
    }
    public bool IsMissionExecution { get; protected set; }
    public bool IsEndMission { get; protected set; }

    public void StartMission()
    {
        if (!_isCanBeStarted || IsEndMission || IsMissionExecution)
        {
            return;
        }
        IsMissionExecution = true;
        StartCoroutine(MissionExecution());
    }
    protected bool CheckClearConditions()
    {
        foreach (var condition in _clearConditions)
        {
            if (!condition.ClearConditions())
            {
                return false;
            }
        }
        return true;
    }
    protected void GiveARewards()
    {
        foreach (var reward in _rewards)
        {
            reward.GiveAReward();
        }
    }
    protected IEnumerator MissionExecution()
    {
        while (!CheckClearConditions())
        {
            yield return null;
        }
        GiveARewards();
        IsMissionExecution = false;
        IsEndMission = true;
    }
}
