using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class EnemyHP : HPManager
    {
        /// <summary>�G�l�~�[��HP</summary>
        [SerializeField] int _enemyHp;
        /// <summary>���Z����X�R�A</summary>
        int ADD_SCORE = 1;
        /// <summary>HP�̉���</summary>
        int  MINI_HP = 0;

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _enemyHp -= IDamage._enemyDamage;
                
                if (_enemyHp <= MINI_HP)
                {
                    Destroy(gameObject);
                    ScoreManager.AddScore(ADD_SCORE);
                }

            }
        }
        public void Damage(int damage)
        {
            _enemyHp -= damage;
            if (_enemyHp <= MINI_HP)
            {
                Destroy(gameObject);
                ScoreManager.AddScore(ADD_SCORE);
            }
        }
    }
}
