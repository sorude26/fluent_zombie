using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponBase
{
    [SerializeField,Tooltip("槍のアニメーション")]
    Animation _spearAnim;
    private Damage _damage = default;

    private void OnEnable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire1,this.Attack);
    }

    private void OnDisable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire1, this.Attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamageApplicable target))
        {
            target.AddDamage(_damage);
        }
    }

    public override void Attack()
    {
        StartShot(GetDamage());
    }
    public void StartShot(Damage damage)
    {
        _spearAnim.Play();
        _damage = damage;
    }
}
