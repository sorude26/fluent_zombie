using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponBase
{
    [SerializeField, Tooltip("���̃A�j���[�V����")]
    Animation _spearAnim;
    [SerializeField, Tooltip("�_���[�W�N���X")]
    Damage _damage = default;
    [SerializeField, Tooltip("�`���[�W�N���X")]
    Charge _charge = default;
    [SerializeField, Tooltip("�`���[�W�̏����")]
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
