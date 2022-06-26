using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武装の基底クラス
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected WeaponParameter _parameter = default;
    protected CharacterParameter _owner = default;
    /// <summary>
    /// 所有者を設定し、初期化する
    /// </summary>
    /// <param name="owner"></param>
    public virtual void Initialize(CharacterParameter owner)
    {
        _owner = owner;
    }
    /// <summary>
    /// この武器のダメージを返す
    /// </summary>
    /// <returns></returns>
    protected virtual Damage GetDamage()
    {
        //Ownerのパラメータ変動でダメージが変動する為newする
        return new Damage(_parameter.Damage + _owner.DefaultPower);
    }
    /// <summary>
    /// 攻撃を行う
    /// </summary>
    public abstract void Attack();
}
