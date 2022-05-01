using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// <summary>スコア合計</summary>
    static int _score;

    private void Start()
    {
        Debug.Log("Scoce:" + _score);
    }
    public void PlayerHP()
    {
        _playerHp -= _enemyAttack;
        //_playerHpText.text += _playerHp;
        Debug.Log( "プレイヤーのHP:" + _playerHp);

        if(_playerHp <= 0)
        {
            Debug.Log("ゲームオーバー");
        }
    }

    public void Score()
    {
        _score += _enemyScore;
        //_scoreText.text += _score;
        Debug.Log( "Scoce:" + _score);
    }
}
