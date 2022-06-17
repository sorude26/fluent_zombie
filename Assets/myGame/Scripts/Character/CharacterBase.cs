using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    protected int _id = default;
    protected CharacterParameter _parameter = default;
    protected virtual void Dead()
    {
        GameData.Instance.SetCount(_id);
    }
}
