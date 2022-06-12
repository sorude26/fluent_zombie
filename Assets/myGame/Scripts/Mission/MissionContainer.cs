using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����̃~�b�V�������܂Ƃ߂�N���X
/// </summary>
[CreateAssetMenu(menuName ="MissionContainer")]
public class MissionContainer : ScriptableObject
{
    //[SerializeField,Header("���ʃ~�b�V����")]
    //private MissionBase _pickupMission = default;
    [SerializeField,Header("�S�~�b�V����")]
    private MissionBase[] _allMissions = default;
    [SerializeField, Header("�S�R���e�i")]
    private MissionContainer[] _containers = default;
    /// <summary>
    /// ��������~�b�V�����̊J�n�\�Ȃ��̂�S�ĊJ�n����
    /// </summary>
    public void CheckMissionStart()
    {
        foreach (var mission in _allMissions)
        {
            if (mission == null || !mission.IsCanBeStarted) { continue; }
            mission.StartMission();
        }
        foreach (var container in _containers)
        {
            if (container == null) { continue; }
            container.CheckMissionStart();
        }
    }
    public void CheckMissionClear()
    {
        foreach (var mission in _allMissions)
        {
            if (mission == null || !mission.IsMissionExecution) { continue; }
            mission.CheckMissionClear();
        }
        foreach (var container in _containers)
        {
            if (container == null) { continue; }
            container.CheckMissionClear();
        }
    }
}
