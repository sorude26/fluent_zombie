using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    /// <summary>�v���C���[�̍U���l</summary>
    public int _playerAttack = 1;
    /// <summary>�v���C���[��HP</summary>
    public int _playerHp = 10;
    /// <summary>�G�l�~�[�̍U���l</summary>
    public int _enemyAttack = 2;
    /// <summary>�G�l�~�[���^����X�R�A</summary>
    [SerializeField] int _enemyScore = 1;
    /// <summary>�v���C���[��HP�e�L�X�g</summary>
    [SerializeField] Text _playerHpText;
    /// <summary>�G�l�~�[��HP�e�L�X�g</summary>
    [SerializeField] Text _scoreText;
    /// <summary>���G����</summary>
    public float _noDamagiTime = 2;
    /// <summary>�X�R�A���v</summary>
    static int _score;
    /// <summary>���G���Ԃ�Bool</summary>
    public bool _noDamagiBool = false;

    private void Start()
    {
        Debug.Log("Scoce:" + _score);
    }

    public void PlayerHP()
    {
        if (_noDamagiBool == true) return;
        _playerHp -= _enemyAttack;
        //_playerHpText.text += _playerHp;
        Debug.Log( "�v���C���[��HP:" + _playerHp);
        _noDamagiBool = true;
        if (_playerHp <= 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
    }
}
