using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    private float time;

    //発射角度のランダム値
    private int randomX;
    private int randomY;
    private int randomZ;
    private GameObject _player;

    Rigidbody _rb;

    //ファイヤーボールの速度
    [SerializeField] float _power;

    //発射角度のランダム値上限
    [SerializeField] int _randomMax;
    //発射角度のランダム値下限
    [SerializeField] int _randomMin;
    //玉が消えるまでの時間
    [SerializeField] float deleteTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
        randomX = Random.Range(_randomMin, _randomMax);
        randomY = Random.Range(_randomMin, _randomMax);
        randomZ = Random.Range(_randomMin, _randomMax);
        this.transform.position = _player.transform.position;
        this.transform.localEulerAngles = new Vector3(_player.transform.localEulerAngles.x + randomX, _player.transform.localEulerAngles.y + randomY, _player.transform.localEulerAngles.z + randomZ);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(transform.forward.normalized * _power, ForceMode.Impulse);

        time += Time.deltaTime;
        if(time >= deleteTime)
        {
            Destroy(this.gameObject);
        }
    }
}
