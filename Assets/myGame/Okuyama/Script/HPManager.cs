using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Perapera_Puroto;

public class HPManager : MonoBehaviour
{
    /// <summary>プレイヤーの攻撃値</summary>
    public int _playerAttack = 1;
    /// <summary>プレイヤーのHP</summary>
    public int _playerHp = 10;
    /// <summary>エネミーの攻撃値</summary>
    public int _enemyAttack = 2;
    /// <summary>エネミーが与えるスコア</summary>
    [SerializeField] int _enemyScore = 1;
    /// <summary>プレイヤーのHPテキスト</summary>
    [SerializeField] Text _playerHpText;
    /// <summary>エネミーのHPテキスト</summary>
    [SerializeField] Text _scoreText;
    /// <summary>無敵時間</summary>
    public float _noDamagiTime = 2;
    /// <summary>スコア合計</summary>
    static int _score;
    /// <summary>無敵時間のBool</summary>
    public bool _noDamagiBool = false;
    public void UpdateHP()
    {
        _playerHpText.text = "HP:" + _playerHp;
    }

    public void PlayerHP()
    {
        if (_noDamagiBool == true) return;
        _playerHp -= _enemyAttack;
        UpdateHP();
        //Debug.Log( "プレイヤーのHP:" + _playerHp);
        _noDamagiBool = true;
        if (_playerHp <= 0)
        {
           GameManager.Instance.GameOver();
           // Debug.Log("ゲームオーバー");
        }
    }
}
