using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Horizontal��Vertical�p�̕ϐ�
    float h;
    float v;
    float time;

    //�����łĂ邩�ǂ����̔���
    bool fireFire;
    //���̌��Ă鐔
    [SerializeField] int fireBullets;
    //���̃}�K�W����
    float fireBakyun;


    Rigidbody rb;
    Vector3 dir;
    //�O���Position
    Vector3 latestPos;

    //�ړ����x�ύX�p�̒l
    [SerializeField] float _MovePower = 10;
    //�ړ����x�̍ō��l
    [SerializeField] float _MoveMaxPower = 10;

    //�t�@�C���[�{�[��
    [SerializeField] FireBallScript fireBall;
    //�t�@�C���[�{�[���̘A�ˊԊu
    [SerializeField] float _rapidFireTime = 1;

    //�c�e�X���C�_�[
    [SerializeField] Slider slider;

    [SerializeField] Transform _muzzle = default;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireBakyun = fireBullets;
        fireFire = true;

        if (slider != null)
        {
            slider.maxValue = fireBullets;    // Slider�̍ő�l��G�L������HP�ő�l�ƍ��킹��
            fireBakyun = fireBullets;
            slider.value = fireBakyun;	// Slider�̏�����Ԃ�ݒ�iHP���^���j
        }
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        dir = Vector3.forward * v + Vector3.right * h;
        dir.y = 0;

        //�L�����N�^�[�̌�������͂ɉ����ĕς���
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
            //�A�ː����̎��ԉ��Z
            if (time < _rapidFireTime)
            {
                time += Time.deltaTime;
            }
            //�t�@�C���[�{�[������
            if (fireFire)
            {
                if (Input.GetButton("Fire1") && time >= _rapidFireTime)
                {
                    var f = Instantiate(fireBall);
                    f.transform.position = _muzzle.position;
                    f.StartShot(transform);
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
            //�X���C�_�[�̕\���X�V
            slider.value = fireBakyun;

            //�c�e�̊Ǘ�
            if (fireBakyun <= 0)
            {
                fireFire = false;
            }
            //Debug.Log(fireFire);
            //Debug.Log(fireBakyun);
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
