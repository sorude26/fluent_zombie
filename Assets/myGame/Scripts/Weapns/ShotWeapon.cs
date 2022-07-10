using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWeapon : WeaponBase
{
    [SerializeField]
    protected Transform _muzzle = default;
    [SerializeField]
    protected WeaponBullet _bullet = default;
    [SerializeField]
    protected float _shotInterval = 0.5f;
    [SerializeField]
    protected Charge _chargeControl = default;
    [SerializeField]
    protected float _chargeConsumption = 0.1f;
    protected float _shotTimer = default;
    protected bool _isShooting = false;
    protected bool _isChargeing = false;

    private void OnEnable()
    {
        PlayerInput.SetEnterInput(InputType.Fire1, this.Attack);
    }
    private void OnDisable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire1, this.Attack);
    }
    private void LateUpdate()
    {
        if (_shotInterval > _shotTimer)
        {
            _shotTimer += Time.deltaTime;
        }
        _isShooting = false;
        _isChargeing = false;
    }
    public override void Attack()
    {
        if (_shotInterval > _shotTimer || _isChargeing) { return; }
        _chargeControl.ChargeMax(_chargeConsumption);
        _isShooting = true;
        _shotTimer = 0;
        var bullet = BulletPool.Instance.GetBullet(_bullet);
        bullet.transform.position = _muzzle.position;
        bullet.transform.forward = _muzzle.forward;
        bullet.StartShot(GetDamage());
    }
    /// <summary>
    /// エネルギーをチャージする
    /// </summary>
    public virtual void Charge()
    {
        if (_isShooting) { return; }
        _isChargeing = true;
        _chargeControl.Chargeing();
    }
}
