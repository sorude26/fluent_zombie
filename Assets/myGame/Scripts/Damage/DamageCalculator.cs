using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �_���[�W�v�Z���s��
/// </summary>
public static class DamageCalculator
{
    public static int GetDamage(CharacterParameter parameter,Damage damage)
    {
        return damage._damage;
    }
}
