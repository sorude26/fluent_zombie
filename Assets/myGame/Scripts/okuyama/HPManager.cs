using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Perapera_Puroto
{
    public class HPManager : MonoBehaviour
    {
        /// <summary>�G�l�~�[���^����X�R�A</summary>
        [SerializeField] int _enemyScore = 1;
        /// <summary>�v���C���[��HP�e�L�X�g</summary>
        [SerializeField] Text _playerHpText;
        /// <summary>�G�l�~�[��HP�e�L�X�g</summary>
        [SerializeField] Text _scoreText;
        /// <summary>�v���C���[��HP</summary>
        protected int _playerHp = 10;
        /// <summary>�G�l�~�[�̍U���l</summary>
        protected int _enemyAttack = 2;
        /// <summary>���G����</summary>
        protected float _noDamagiTime = 2;
        /// <summary>���G���Ԃ�Bool</summary>
        protected bool _noDamagiBool = false;
        /// <summary>�v���C���[HP�̉���</summary>
        int MINI_PLAYER_HP = 0;
        /// <summary>�v���C���[�̍U���l</summary>
        public int _playerAttack = 1;
        protected Damage IDamage;
        private void Start()
        {
            IDamage = new Damage(_enemyAttack, _playerAttack);
        }

        public void UpdateHP()
        {
            _playerHpText.text = "HP:" + _playerHp;
        }

        public void PlayerHP()
        {
            if (_noDamagiBool == true) return;
            _playerHp -= IDamage._damage;
            UpdateHP();
            
            _noDamagiBool = true;
            if (_playerHp <= MINI_PLAYER_HP)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
