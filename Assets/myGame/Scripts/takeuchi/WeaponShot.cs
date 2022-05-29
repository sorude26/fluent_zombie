using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody _rb = default;
    private Damage _damage = default;
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
    public void StartShot(Damage damage)
    {
        _damage = null;
        _damage = damage;
    }
}
