using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Charge : MonoBehaviour
{
    [SerializeField, Tooltip("�`���[�W���ɕ�����g���Ȃ�����")] 
    UnityEvent _chargeing;
    [SerializeField, Tooltip("�`���[�W�������ɕ�����g����悤�ɂ���")] 
    UnityEvent _chargeEnd;
    [Tooltip("�`���[�W�܂łɎg���鎞��")] 
    float _chargeTimer = 5.0f;
    [Tooltip("�`���[�W�̍ő�l")] 
    float _chargeMax = 10;
    [Tooltip("���˂ł���")]
    public bool _chargebool = true;
    [Tooltip("�`���[�W�X�s�[�h")] 
    float _chargeSpeed;

    private void OnEnable()
    {
        PlayerInput.SetEnterInput(InputType.Fire2, this.Chargeing);
    }

    private void OnDisable()
    {
        PlayerInput.LiftEnterInput(InputType.Fire2, this.UpCharge);
    }

    private void UpCharge()//�`���[�W�{�^���𗣂����Ƃ�
    {
        _chargebool = true;
    }

    /// <summary>�`���[�W����</summary>
    public void Chargeing()
    {
        _chargeTimer += _chargeSpeed * Time.deltaTime;
        if (_chargeTimer > _chargeMax)
        {
            _chargeTimer = _chargeMax;
            _chargebool = true;
            _chargeEnd.Invoke();
        }
    }

    /// <summary>�Q�[�W�����炷</summary>
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
