using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage 
{
    /// <summary>�v���C���[���󂯂�_���[�W</summary>
    public int _damage { get; }

    public Damage(int _nomalDamage)
    {
        _damage = _nomalDamage;
    }
    enum Type
    {
        //��
        Scissors = 0,
        Bom = 1
    }
}
