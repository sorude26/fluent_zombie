using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponBase
{
    [SerializeField, Tooltip("槍のアニメーション")]
    Animation _spearAnim;
    [SerializeField, Tooltip("ダメージクラス")]
    Damage _damage = default;
    [SerializeField, Tooltip("チャージクラス")]
    Charge _charge = default;
    [SerializeField, Tooltip("チャージの消費量")]
    float _chargeConsumption;

    private void OnEnable()
    {
        PlayerInput.SetEnterInput(InputType.Fire1,this.Attack);
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
        if(_charge._chargebool == false) { return; }
        StartShot(GetDamage());
        _charge.ChargeMax(_chargeConsumption);
    }
    public void StartShot(Damage damage)
    {
        _spearAnim.Play();
        _damage = damage;
    }
}
