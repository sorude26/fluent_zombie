using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ߋ����p
/// </summary>
public class ShortRangeAttack : WeaponBase
{
    [SerializeField, Tooltip("�A�j���[�V����")]
    Animation _spearAnim;
    [SerializeField, Tooltip("�_���[�W�N���X")]
    Damage _damage = default;
    [SerializeField, Tooltip("�`���[�W�N���X")]
    Charge _charge = default;
    [SerializeField, Tooltip("�`���[�W�̏����")]
    float _chargeConsumption = 0.5f;
    [SerializeField, Tooltip("�C���^�[�o��")]
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
