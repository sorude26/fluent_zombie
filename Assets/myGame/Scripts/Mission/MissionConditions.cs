using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ミッションの条件設定基底クラス
/// </summary>
public abstract class MissionConditions : ScriptableObject
{
    /// <summary>
    /// 条件を満たしている場合はtrue
    /// </summary>
    /// <returns></returns>
    public abstract bool ClearConditions();
}
