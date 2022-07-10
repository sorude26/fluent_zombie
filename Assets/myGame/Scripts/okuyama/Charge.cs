using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Charge : MonoBehaviour
{
    [SerializeField, Tooltip("チャージまでに使える時間")] 
    float _chargeTimer = 5.0f;
    [SerializeField, Tooltip("チャージの最大値")] 
    float _chargeMax = 10;
    [SerializeField, Tooltip("チャージスピード")]
    float _chargeSpeed;
    [Tooltip("発射できる")]
    public bool _chargebool = true;

    private void OnEnable()
    {
        PlayerInput.SetStayInput(InputType.Fire2, this.Chargeing);
    }

    private void OnDisable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire2, this.UpCharge);
    }

    private void UpCharge()//チャージボタンを離したとき
    {
        _chargebool = true;
    }

    /// <summary>チャージする</summary>
    public void Chargeing()
    {
        _chargeTimer += _chargeSpeed * Time.deltaTime;
        if (_chargeTimer > _chargeMax)
        {
            _chargeTimer = _chargeMax;
            _chargebool = true;
        }
    }

    /// <summary>ゲージを減らす</summary>
    /// <param name="decrease"></param>
    public void ChargeMax(float decrease)
    {
        if (_chargeTimer > 0 && _chargebool == true)
        {
            _chargeTimer -= decrease;
            if (_chargeTimer <= 0)
            {
                _chargebool = false;
            }
        }
    }
}
