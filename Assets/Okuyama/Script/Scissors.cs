using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    /// <summary>ハサミの攻撃値</summary>
    [SerializeField] int _scissorsAttack = 5;
    /// <summary>ハサミのアニメーション</summary>
    Animator _scissorsAnim;
    /// <summary>エネミーのHPスクリプト</summary>
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
    // アニメーションが終了したときに呼ばれるメソッド
    public void ScissorsAnimStop()
    {
        _enemyHPScript._playerAttack = _scissorsAttack;
        //Debug.Log(_enemyHPScript._playerAttack);
    }
}
