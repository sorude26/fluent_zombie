using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �~�b�V�����̕�V���N���X
/// </summary>
public abstract class MissionReward : ScriptableObject
{
    /// <summary>
    /// ��V��^����
    /// </summary>
    public abstract void GiveAReward();
}
