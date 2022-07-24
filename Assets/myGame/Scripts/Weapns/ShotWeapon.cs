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
    [SerializeField]
    protected float _diffusivity = 0;
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
        bullet.transform.forward = Diffusivity(_muzzle.forward, _diffusivity);
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
    protected Vector3 Diffusivity(Vector3 target,float diffusivity)
    {
        if (diffusivity > 0)
        {
            target.x += Random.Range(-diffusivity, diffusivity);
            target.y += Random.Range(-diffusivity, diffusivity);
            target.z += Random.Range(-diffusivity, diffusivity);
        }
        return target;
    }
}
