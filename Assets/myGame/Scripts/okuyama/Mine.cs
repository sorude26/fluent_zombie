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
        }
        if(other.gameObject.tag == "Player") { StartCoroutine(Stop()); }
    }
    public void StartShot(Damage damage)
    {
        //_spearAnim.Play();
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2);
        //Destroy(this.gameObject);
    }
}
