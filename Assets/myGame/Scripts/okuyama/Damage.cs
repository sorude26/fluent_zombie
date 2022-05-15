using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage 
{
    /// <summary>プレイヤーが受けるダメージ</summary>
    public int _damage { get; }

    public Damage(int _nomalDamage)
    {
        _damage = _nomalDamage;
    }
    enum Type
    {
        //仮
        Scissors = 0,
        Bom = 1
    }
}
