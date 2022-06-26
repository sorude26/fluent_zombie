using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="WeaponParameter")]
public class WeaponParameter : ScriptableObject
{
    [SerializeField, Header("武器名称")]
    protected string _weaponName = "";
    [SerializeField, Header("武器種")]
    protected WeaponType _weapnType = default;
    [SerializeField, Header("属性")]
    protected AttributeType _attributeType = default;
    [SerializeField, Header("ダメージ")]
    protected int _weaponDamage = 1;
    [SerializeField, Header("武器種類値")]
    protected float _weaponTypePower = 0f;
    [SerializeField, Header("属性値")]
    protected float _attributePower = 0f;
    /// <summary> 武器名称 </summary>
    public string Name { get => _weaponName; }
    /// <summary> 武器種類 </summary>
    public WeaponType WeaponType { get => _weapnType; }
    /// <summary> 属性種類 </summary>
    public AttributeType AttributeType { get => _attributeType; }
    /// <summary> ダメージ量 </summary>
    public int Damage { get => _weaponDamage; }
    /// <summary> 武器種補正値 </summary>
    public float WeaponPower { get => _weaponTypePower; }
    /// <summary> 属性補正値 </summary>
    public float AttributePower { get => _attributePower; }

}
