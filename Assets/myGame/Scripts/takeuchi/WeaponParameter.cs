using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParameter : ScriptableObject
{
    [SerializeField, Header("���햼��")]
    protected string _weaponName = "";
    [SerializeField, Header("�����")]
    protected WeaponType _weapnType = default;
    [SerializeField, Header("����")]
    protected AttributeType _attributeType = default;
    [SerializeField, Header("�_���[�W")]
    protected int _weaponDamage = 1;
    [SerializeField, Header("�����ޒl")]
    protected float _weaponTypePower = 0f;
    [SerializeField, Header("�����l")]
    protected float _attributePower = 0f;
    /// <summary> ���햼�� </summary>
    public string Name { get => _weaponName; }
    /// <summary> ������ </summary>
    public WeaponType WeaponType { get => _weapnType; }
    /// <summary> ������� </summary>
    public AttributeType AttributeType { get => _attributeType; }
    /// <summary> �_���[�W�� </summary>
    public int Damage { get => _weaponDamage; }
    /// <summary> �����␳�l </summary>
    public float WeaponPower { get => _weaponTypePower; }
    /// <summary> �����␳�l </summary>
    public float AttributePower { get => _attributePower; }

}
