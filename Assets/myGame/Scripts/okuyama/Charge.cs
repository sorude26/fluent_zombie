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
    [Tooltip("���˂ł��邩")] 
    bool _chargebool = false;
    [Tooltip("�`���[�W�X�s�[�h")] 
    float _chargeSpeed;
    [Tooltip("�`���[�W����̌�����")] 
    float _decrease;

    void Start()
    {
        
    }
       
    void Update()
    {
        ChargeMax();
        if (Input.GetKey(KeyCode.Q))//�`���[�W�J�n
        {
            Chargeing();
        }
        if (Input.GetKeyUp(KeyCode.Q))//�`���[�W�{�^���𗣂����Ƃ�
        {
            UpCharge();
        }
    }

    private void UpCharge()//�`���[�W�{�^���𗣂����Ƃ�
    {
        _chargebool = false;
        _chargeEnd.Invoke();
    }

    private void Chargeing()//�`���[�W���Ȃ��Ƃ�
    {
        _chargeTimer += _chargeSpeed * Time.deltaTime;
        if (_chargeTimer > _chargeMax)
        {
            Debug.Log($"�`���[�W�}�b�N�X{_chargeTimer}");
            _chargeTimer = _chargeMax;
            _chargebool = false;
            _chargeEnd.Invoke();
        }
    }
    private void ChargeMax()//�`���[�W������Ƃ�
    {
        if (_chargeTimer > 0 && _chargebool == false)
        {
            _chargeTimer -= _decrease;
            if (_chargeTimer <= 0)
            {
                _chargeing.Invoke();
                _chargebool = true;
                Debug.Log($"�`���[�W�����Ȃ���{_chargeTimer}");
            }
        }
    }
}
