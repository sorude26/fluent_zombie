using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    /// <summary>�n�T�~�̍U���l</summary>
    [SerializeField] int _scissorsAttack = 5;
    /// <summary>�n�T�~�̃A�j���[�V����</summary>
    Animator _scissorsAnim;
    /// <summary>�G�l�~�[��HP�X�N���v�g</summary>
    EnemyHP _enemyHPScript;

    private void Start()
    {
        _scissorsAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemyHPScript = other.gameObject.GetComponent<EnemyHP>();
            _scissorsAnim.SetTrigger("ScissorsTrigger");
        }
    }
    // �A�j���[�V�������I�������Ƃ��ɌĂ΂�郁�\�b�h
    public void ScissorsAnimStop()
    {
        _enemyHPScript._playerAttack = _scissorsAttack;
        //Debug.Log(_enemyHPScript._playerAttack);
    }
}
