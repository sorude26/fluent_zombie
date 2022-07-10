using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �e�ۂ̑���N���X
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class WeaponBullet : MonoBehaviour
{
    [SerializeField]
    protected float _lifeTime = 2f;
    [SerializeField]
    protected float _speed = 5f;
    [SerializeField]
    protected Rigidbody _rb = default;
    private Damage _damage = default;
    protected float _lifeTimer = default;
    private void Update()
    {
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer > _lifeTime) { gameObject.SetActive(false); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageApplicable target))
        {
            target.AddDamage(_damage);
            gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// �_���[�W��ݒ肵�A�ړ��J�n����
    /// </summary>
    public virtual void StartShot(Damage damage)
    {
        _damage = damage;
        _lifeTimer = 0;
        gameObject.SetActive(true);
        _rb.velocity = transform.forward * _speed;
    }
}
