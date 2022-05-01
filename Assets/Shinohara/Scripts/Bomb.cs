using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField, Header("�����̒��S")] Vector3 _explosionCenter = default;
    [SerializeField, Header("�������a")] float _explosionRadius = 5f;
    [SerializeField, Header("�N���܂ł̎���")] float _explosionTime = 3f;
    [SerializeField, Header("��΂����ɂ������")] float _forcePower = 10f;
    [SerializeField] GameObject _effect = default;

    private void OnDrawGizmosSelected() //�����͈͂̃M�Y����\������
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetCenter(), _explosionRadius);
    }

    /// <summary>�����̒��S���擾����</summary>
    /// <returns>�����̒��S</returns>
    Vector3 GetCenter()
    {
        Vector3 center = this.transform.position + this.transform.forward * _explosionCenter.z
           + this.transform.up * _explosionCenter.y
           + this.transform.right * _explosionCenter.x;
        return center;
    }

    /// <summary>��莞�Ԍ㔚�e���N�������G�Ƀ_���[�W��^���� </summary>
    private IEnumerator StartUp()
    {
        yield return new WaitForSeconds(_explosionTime);
        //Debug.Log("�N��");
        if (_effect)
        {
            Instantiate(_effect).transform.position = GetCenter();
        }
        var cols = Physics.OverlapSphere(GetCenter(), _explosionRadius);   //�������Ă���I�u�W�F�N�g��S�Ď擾���邷��
    
        foreach (var c in cols)
        {
            if (c.gameObject.tag == "Enemy")   //�������Ă���I�u�W�F�N�g����Enemy��������폜����
            {
                Destroy(c.gameObject);
                ScoreManager.AddScore();
            }
        }

        Destroy(this.gameObject);
    }

    /// <summary>�I�u�W�F�N�g�ɗ͂������Ĕ�΂� �����������ɌĂ�ŗ~���� </summary>
    /// <param name="playerForward">�v���C���[�̌����Ă������</param>
    public void AddForce(Vector3 playerForward)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(playerForward * _forcePower, ForceMode.Impulse);
        StartCoroutine(StartUp());
    }
}
