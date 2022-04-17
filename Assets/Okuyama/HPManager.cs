using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    /// <summary>�v���C���[�̍U���l</summary>
    public int _playerAttack = 2;
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
    /// <summary>�X�R�A���v</summary>
    static int _score;

    private void Start()
    {
        Debug.Log("Scoce:" + _score);
    }
    public void PlayerHP()
    {
        _playerHp -= _enemyAttack;
        _playerHpText.text += _playerHp;
        Debug.Log( "�v���C���[��HP:" + _playerHp);

        if(_playerHp <= 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
    }

    public void Score()
    {
        _score += _enemyScore;
        _scoreText.text += _score;
        Debug.Log( "Scoce:" + _score);
    }
}
