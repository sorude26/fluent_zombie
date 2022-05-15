using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class EnemyHP : HPManager
    {
        /// <summary>エネミーのHP</summary>
        [SerializeField] int _enemyHp;

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _enemyHp -= _playerAttack;
                // Debug.Log("EnemyHP:" + _enemyHp);
                if (_enemyHp <= 0)
                {
                    Destroy(gameObject);
                    ScoreManager.AddScore(1);
                }

            }
        }
        public void Damage(int damage)
        {
            _enemyHp -= damage;
            if (_enemyHp <= 0)
            {
                Destroy(gameObject);
                ScoreManager.AddScore(1);
            }
        }
    }
}
