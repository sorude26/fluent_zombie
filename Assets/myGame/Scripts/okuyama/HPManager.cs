using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Perapera_Puroto
{
    public class HPManager : MonoBehaviour
    {
        /// <summary>エネミーが与えるスコア</summary>
        [SerializeField] int _enemyScore = 1;
        /// <summary>プレイヤーのHPテキスト</summary>
        [SerializeField] Text _playerHpText;
        /// <summary>エネミーのHPテキスト</summary>
        [SerializeField] Text _scoreText;
        /// <summary>プレイヤーのHP</summary>
        protected int _playerHp = 10;
        /// <summary>エネミーの攻撃値</summary>
        protected int _enemyAttack = 2;
        /// <summary>無敵時間</summary>
        protected float _noDamagiTime = 2;
        /// <summary>無敵時間のBool</summary>
        protected bool _noDamagiBool = false;
        /// <summary>プレイヤーHPの下限</summary>
        int MINI_PLAYER_HP = 0;
        /// <summary>プレイヤーの攻撃値</summary>
        public int _playerAttack = 1;

        public void UpdateHP()
        {
            _playerHpText.text = "HP:" + _playerHp;
        }

        public void PlayerHP()
        {
            if (_noDamagiBool == true) return;
            _playerHp -= _enemyAttack;
            UpdateHP();
            
            _noDamagiBool = true;
            if (_playerHp <= MINI_PLAYER_HP)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
