using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Mission���N���X
/// </summary>
[CreateAssetMenu(menuName = "Mission")]
public class MissionBase : MonoBehaviour
{
    [SerializeField, Header("�~�b�V������")]
    protected string _missionName = "";
    [SerializeField, Header("�~�b�V�����̊J�n����")]
    protected MissionConditions[] _startConditions = null;
    [SerializeField, Header("�~�b�V�����̃N���A����")]
    protected MissionConditions[] _clearConditions = null;
    [SerializeField, Header("�~�b�V�����̕�V")]
    protected MissionReward[] _rewards = null;
    protected bool _isCanBeStarted = default;
    public string MissionName { get => _missionName; }
    /// <summary> �J�n�\�t���O </summary>
    public bool IsCanBeStarted
    {
        get
        {
            if (IsEndMission || IsMissionExecution) { return false; }
            if (_isCanBeStarted) { return true; }
            //�X�^�[�g������S�Ė������Ă��邩�m�F����
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
    /// <summary> ���s���t���O </summary>
    public bool IsMissionExecution { get; protected set; }
    /// <summary> �I���t���O </summary>
    public bool IsEndMission { get; protected set; }
    /// <summary>
    /// �~�b�V�������J�n����
    /// </summary>
    public void StartMission()
    {
        if (!_isCanBeStarted || IsEndMission || IsMissionExecution)
        {
            return;
        }
        IsMissionExecution = true;
        CheckMissionClear();
    }
    /// <summary>
    /// �N���A�����𖞂����Ă��邩�Ԃ�
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
    /// ��V��^����
    /// </summary>
    protected void GiveARewards()
    {
        foreach (var reward in _rewards)
        {
            reward.GiveAReward();
        }
    }
    /// <summary>
    /// �~�b�V�������s�����A�N���A�����𖞂����ƕ�V��^����
    /// </summary>
    /// <returns></returns>
    public void CheckMissionClear()
    {
        if (!CheckClearConditions()) { return; }
        GiveARewards();
        IsMissionExecution = false;
        IsEndMission = true;
    }
}
