using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �L�����N�^�[�̃p�����[�^�N���X
/// </summary>
public class CharacterParameter
{
    /// <summary> ����퐔 </summary>
    public readonly int WEAPON_TYPES = Enum.GetValues(typeof(TWeaponType)).Length;
    /// <summary> �����퐔 </summary>
    public readonly int ATTRIBUTE_TYPES = Enum.GetValues(typeof(TAttributeType)).Length;
    /// <summary> �S�����퐔 </summary>
    public readonly int ALL_ATTRIBUTE_TYPE_NUMBER = Enum.GetValues(typeof(TWeaponType)).Length + Enum.GetValues(typeof(TAttributeType)).Length;
    /// <summary> �ő�ϋv�l </summary>
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
    /// <summary> �ϋv�l </summary>
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
    /// <summary> ��b�U���� </summary>
    public int DefaultPower 
    {
        get => _power;
        set 
        {
            _power = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �ړ����x </summary>
    public float MoveSpeed
    {
        get => _moveSpeed;
        set
        {
            _moveSpeed = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �ő�`���[�W�� </summary>
    public float MaxChargePoint
    {
        get => _maxChage;
        set
        {
            _maxChage = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �`���[�W�� </summary>
    public float CurrentChargePoint
    {
        get => _chage;
        set
        {
            _chage = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �`���[�W���x </summary>
    public float ChargeSpeed
    {
        get => _chageSpeed;
        set
        {
            _chageSpeed = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �U�������l </summary>
    public float[] AttributePower
    {
        get => _attributePower;
        set
        {
            _attributePower = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> �����ϐ��l </summary>
    public float[] Resistances
    {
        get => _resistances;
        set
        {
            _resistances = value;
            DelUpdateParameter?.Invoke();
        }
    }
    /// <summary> Parameter�X�V���̃C�x���g </summary>
    public event Action DelUpdateParameter = default;
    /// <summary> ���S���ɌĂ΂��C�x���g </summary>
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
/// �����
/// </summary>
public enum TWeaponType
{
    LongRange,
    MiddleRange,
    ShortRange,
    Throw,
}
/// <summary>
/// ������
/// </summary>
public enum TAttributeType
{
    Fire,
    Water,
    Wind,
    Null,
}