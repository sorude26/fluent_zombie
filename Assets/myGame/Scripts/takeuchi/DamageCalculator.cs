using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダメージ計算を行う
/// </summary>
public static class DamageCalculator
{
    public static int GetDamage(CharacterParameter parameter,Damage damage)
    {
        return damage._damage;
    }
}
