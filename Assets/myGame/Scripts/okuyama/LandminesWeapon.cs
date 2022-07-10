using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地雷生成
/// </summary>
public class LandminesWeapon : WeaponBase
{
    [SerializeField, Tooltip("ダメージクラス")]
    Mine _mine = default;
    [SerializeField, Tooltip("チャージクラス")]
    Charge _charge = default;
    [SerializeField, Tooltip("チャージの消費量")]
    float _chargeConsumption = 0.5f;
    [SerializeField, Tooltip("インターバル")]
    float _interval = 0.1f;
    [SerializeField,Tooltip("生成する地雷")]
    GameObject _mines;

    private void OnEnable()
    {
        PlayerInput.SetEnterInput(InputType.Fire1, this.Attack);
    }

    private void OnDisable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire1, this.Attack);
    }

    public override void Attack()
    {
        if (_charge._chargebool == false) { return; }
        Instantiate(_mines, this.gameObject.transform.position, Quaternion.identity);
        _mine.StartShot(GetDamage());
        _charge.ChargeMax(_chargeConsumption);
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(_interval);
        Instantiate(_mines, this.gameObject.transform.position, Quaternion.identity);
        _mine.StartShot(GetDamage());
        _charge.ChargeMax(_chargeConsumption);
    }
}
