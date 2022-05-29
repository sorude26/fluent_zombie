using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラクターのパラメータクラス
/// </summary>
public class CharacterParameter
{
    /// <summary> 武器種数 </summary>
    public readonly int WEAPON_TYPES = Enum.GetValues(typeof(TWeaponType)).Length;
    /// <summary> 属性種数 </summary>
    public readonly int ATTRIBUTE_TYPES = Enum.GetValues(typeof(TAttributeType)).Length;
    /// <summary> 全属性種数 </summary>
    public readonly int ALL_ATTRIBUTE_TYPE_NUMBER = Enum.GetValues(typeof(TWeaponType)).Length + Enum.GetValues(typeof(TAttributeType)).Length;
    /// <summary> 最大耐久値 </summary>
    public readonly int MAX_HP;
    #region Private Field
    private int _hp = default;
    private int _power = default;
    private float _moveSpeed = default;
    private float _maxChage = default;
    private float _chage = default;
    private float _chageSpeed = default;
    private float[] _attributePower = default;
    private float[] _resistances = default;
    #endregion
    /// <summary> 耐久値 </summary>
    public int CurrentHP 
    {
        get => _hp;
        set 
        {
            _hp = value;
            DelUpdateParameter?.Invoke();
            if (_hp <= 0)
            {
                DelDead?.Invoke();
            }
        }
    }
    /// <summary> 基礎攻撃力 </summary>
    public int DefaultPower 
    {
        get => _power;
        set 
        {
            _power = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> 移動速度 </summary>
    public float MoveSpeed
    {
        get => _moveSpeed;
        set
        {
            _moveSpeed = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> 最大チャージ量 </summary>
    public float MaxChargePoint
    {
        get => _maxChage;
        set
        {
            _maxChage = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> チャージ量 </summary>
    public float CurrentChargePoint
    {
        get => _chage;
        set
        {
            _chage = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> チャージ速度 </summary>
    public float ChargeSpeed
    {
        get => _chageSpeed;
        set
        {
            _chageSpeed = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> 攻撃属性値 </summary>
    public float[] AttributePower
    {
        get => _attributePower;
        set
        {
            _attributePower = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> 属性耐性値 </summary>
    public float[] Resistances
    {
        get => _resistances;
        set
        {
            _resistances = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> Parameter更新時のイベント </summary>
    public event Action DelUpdateParameter = default;
    /// <summary> 死亡時に呼ばれるイベント </summary>
    public event Action DelDead = default;
    public CharacterParameter(float moveSpeed = 5f,int maxHp = 100,float maxCharge = 100,float chageSpeed = 5f)
    {
        MAX_HP = maxHp;
        _hp = maxHp;
        _chage = maxCharge;
        _maxChage = maxCharge;
        _moveSpeed = moveSpeed;
        _chageSpeed = chageSpeed;
        _resistances = new float[ALL_ATTRIBUTE_TYPE_NUMBER];
        _attributePower = new float[ALL_ATTRIBUTE_TYPE_NUMBER];
    }
}
/// <summary>
/// 武器種
/// </summary>
public enum TWeaponType
{
    LongRange,
    MiddleRange,
    ShortRange,
    Throw,
}
/// <summary>
/// 属性種
/// </summary>
public enum TAttributeType
{
    Fire,
    Water,
    Wind,
    Null,
}