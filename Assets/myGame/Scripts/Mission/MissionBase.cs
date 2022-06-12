using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Mission基底クラス
/// </summary>
[CreateAssetMenu(menuName = "Mission")]
public class MissionBase : MonoBehaviour
{
    [SerializeField, Header("ミッション名")]
    protected string _missionName = "";
    [SerializeField, Header("ミッションの開始条件")]
    protected MissionConditions[] _startConditions = null;
    [SerializeField, Header("ミッションのクリア条件")]
    protected MissionConditions[] _clearConditions = null;
    [SerializeField, Header("ミッションの報酬")]
    protected MissionReward[] _rewards = null;
    protected bool _isCanBeStarted = default;
    public string MissionName { get => _missionName; }
    /// <summary> 開始可能フラグ </summary>
    public bool IsCanBeStarted
    {
        get
        {
            if (IsEndMission || IsMissionExecution) { return false; }
            if (_isCanBeStarted) { return true; }
            //スタート条件を全て満たしているか確認する
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
    /// <summary> 実行中フラグ </summary>
    public bool IsMissionExecution { get; protected set; }
    /// <summary> 終了フラグ </summary>
    public bool IsEndMission { get; protected set; }
    /// <summary>
    /// ミッションを開始する
    /// </summary>
    public void StartMission()
    {
        if (!_isCanBeStarted || IsEndMission || IsMissionExecution)
        {
            return;
        }
        IsMissionExecution = true;
        StartCoroutine(MissionExecution());
    }
    /// <summary>
    /// クリア条件を満たしているか返す
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// 報酬を与える
    /// </summary>
    protected void GiveARewards()
    {
        foreach (var reward in _rewards)
        {
            reward.GiveAReward();
        }
    }
    /// <summary>
    /// ミッション実行処理、クリア条件を満たすと報酬を与える
    /// </summary>
    /// <returns></returns>
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
