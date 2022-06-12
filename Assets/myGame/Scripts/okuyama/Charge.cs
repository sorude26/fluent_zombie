using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Charge : MonoBehaviour
{
    [SerializeField, Tooltip("チャージ中に武器を使えなくする")] 
    UnityEvent _chargeing;
    [SerializeField, Tooltip("チャージ完了時に武器を使えるようにする")] 
    UnityEvent _chargeEnd;
    [Tooltip("チャージまでに使える時間")] 
    float _chargeTimer = 5.0f;
    [Tooltip("チャージの最大値")] 
    float _chargeMax = 10;
    [Tooltip("発射できるか")] 
    bool _chargebool = false;
    [Tooltip("チャージスピード")] 
    float _chargeSpeed;
    [Tooltip("チャージからの減少量")] 
    float _decrease;

    void Start()
    {
        
    }
       
    void Update()
    {
        ChargeMax();
        if (Input.GetKey(KeyCode.Q))//チャージ開始
        {
            Chargeing();
        }
        if (Input.GetKeyUp(KeyCode.Q))//チャージボタンを離したとき
        {
            UpCharge();
        }
    }

    private void UpCharge()//チャージボタンを離したとき
    {
        _chargebool = false;
        _chargeEnd.Invoke();
    }

    private void Chargeing()//チャージがないとき
    {
        _chargeTimer += _chargeSpeed * Time.deltaTime;
        if (_chargeTimer > _chargeMax)
        {
            Debug.Log($"チャージマックス{_chargeTimer}");
            _chargeTimer = _chargeMax;
            _chargebool = false;
            _chargeEnd.Invoke();
        }
    }
    private void ChargeMax()//チャージがあるとき
    {
        if (_chargeTimer > 0 && _chargebool == false)
        {
            _chargeTimer -= _decrease;
            if (_chargeTimer <= 0)
            {
                _chargeing.Invoke();
                _chargebool = true;
                Debug.Log($"チャージ無くなった{_chargeTimer}");
            }
        }
    }
}
