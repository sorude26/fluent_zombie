using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ミッションの報酬基底クラス
/// </summary>
public abstract class MissionReward : ScriptableObject
{
    /// <summary>
    /// 報酬を与える
    /// </summary>
    public abstract void GiveAReward();
}
