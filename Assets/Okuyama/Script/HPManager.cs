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
    /// <summary>無敵時間</summary>
    public float _noDamagiTime = 2;
    /// <summary>スコア合計</summary>
    static int _score;
    /// <summary>無敵時間のBool</summary>
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
        Debug.Log( "プレイヤーのHP:" + _playerHp);
        _noDamagiBool = true;
        if (_playerHp <= 0)
        {
            Debug.Log("ゲームオーバー");
        }
    }
}
