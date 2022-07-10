using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 近距離用
/// </summary>
public class ShortRangeAttack : WeaponBase
{
    [SerializeField, Tooltip("アニメーション")]
    Animation _spearAnim;
    [SerializeField, Tooltip("ダメージクラス")]
    Damage _damage = default;
    [SerializeField, Tooltip("チャージクラス")]
    Charge _charge = default;
    [SerializeField, Tooltip("チャージの消費量")]
    float _chargeConsumption = 0.5f;
    [SerializeField, Tooltip("インターバル")]
    float _interval = 2.0f;

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
        StartCoroutine(Interval());
    }

    public void StartShot(Damage damage)
    {
        _spearAnim.Play();
        _damage = damage;
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(_interval);
        StartShot(GetDamage());
        _charge.ChargeMax(_chargeConsumption);
    }
}
