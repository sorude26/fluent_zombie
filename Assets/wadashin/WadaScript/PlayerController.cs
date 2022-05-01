using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //HorizontalとVertical用の変数
    float h;
    float v;
    float time;

    //炎が打てるかどうかの判定
    bool fireFire;
    //炎の撃てる数
    [SerializeField] int fireBullets;
    //炎のマガジン数
    float fireBakyun;


    Rigidbody rb;
    Vector3 dir;
    //前回のPosition
    Vector3 latestPos;

    //移動速度変更用の値
    [SerializeField] float _MovePower = 10;
    //移動速度の最高値
    [SerializeField] float _MoveMaxPower = 10;

    //ファイヤーボール
    [SerializeField] GameObject fireBall;
    //ファイヤーボールの連射間隔
    [SerializeField] float _rapidFireTime = 1;

    //残弾スライダー
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireBakyun = fireBullets;
        fireFire = true;

        if (slider != null)
        {
            slider.maxValue = fireBullets;    // Sliderの最大値を敵キャラのHP最大値と合わせる
            fireBakyun = fireBullets;
            slider.value = fireBakyun;	// Sliderの初期状態を設定（HP満タン）
        }
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        dir = Vector3.forward * v + Vector3.right * h;
        dir.y = 0;

        //キャラクターの向きを入力に応じて変える
        if (v < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (v > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (slider != null)
        {
            //連射制限の時間加算
            if (time < _rapidFireTime)
            {
                time += Time.deltaTime;
            }
            //ファイヤーボール発射
            if (fireFire)
            {
                if (Input.GetButton("Fire1") && time >= _rapidFireTime)
                {
                    Instantiate(fireBall);
                    time = 0;
                    fireBakyun--;
                }
            }
            else
            {
                fireBakyun += 0.1f;
                if (fireBakyun >= fireBullets)
                {
                    fireBakyun = fireBullets;
                    fireFire = true;
                }
            }
            //スライダーの表示更新
            slider.value = fireBakyun;

            //残弾の管理
            if (fireBakyun <= 0)
            {
                fireFire = false;
            }
            Debug.Log(fireFire);
            Debug.Log(fireBakyun);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < _MoveMaxPower)
        {
            rb.AddForce(dir.normalized * _MovePower, ForceMode.Force);
        }
    }
}
