using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage 
{
    /// <summary>�v���C���[���󂯂�_���[�W</summary>
    public int _damage { get; }
    /// <summary>�G�l�~�[���󂯂�_���[�W</summary>
    public int _enemyDamage { get; }

    public Damage(int _nomalDamage ,int _scisorDamage)
    {
        _damage = _nomalDamage;
        _enemyDamage = _scisorDamage;
    }
}
