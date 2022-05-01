using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyHP : HPManager
{
    /// <summary>エネミーのHP</summary>
    int _enemyHp = 4;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerGan")
        {
            _enemyHp -= _playerAttack;
            Debug.Log("EnemyHP:" + _enemyHp);
            if (_enemyHp <= 0)
            {
                Destroy(gameObject);
                ScoreManager.AddScore(1);
            }
            
        }
    }
}
