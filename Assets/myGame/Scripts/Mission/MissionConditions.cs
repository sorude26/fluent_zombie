using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �~�b�V�����̏����ݒ���N���X
/// </summary>
public abstract class MissionConditions : ScriptableObject
{
    /// <summary>
    /// �����𖞂����Ă���ꍇ��true
    /// </summary>
    /// <returns></returns>
    public abstract bool ClearConditions();
}
