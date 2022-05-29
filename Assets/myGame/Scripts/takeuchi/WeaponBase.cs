using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected WeaponParameter _parameter = default;
    protected Damage _damage;
    protected CharacterParameter _owner = default;
    protected virtual Damage GetDamage()
    {
        return new Damage(_parameter.Damage + _owner.DefaultPower);
    }
    public void SetOwner(CharacterParameter owner)
    {
        _owner = owner;
    }
    public abstract void Attack();
}
