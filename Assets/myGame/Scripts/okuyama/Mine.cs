using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �n��
/// </summary>
public class Mine : MonoBehaviour
{
    [SerializeField, Tooltip("�A�j���[�V����")]
    Animation _spearAnim;
    [SerializeField, Tooltip("�_���[�W�N���X")]
    Damage _damage = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageApplicable target))
        {
            target.AddDamage(_damage);
            Destroy(this.gameObject);
        }
    }
    public void StartShot(Damage damage)
    {
        _spearAnim.Play();
    }
}
