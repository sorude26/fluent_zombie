using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Horizontal��Vertical�p�̕ϐ�
    float h;
    float v;

    Rigidbody rb;
    Vector3 dir;
    //�O���Position
    Vector3 latestPos;

    //�ړ����x�ύX�p�̒l
    [SerializeField] float _MovePower = 10;
    //�ړ����x�̍ō��l
    [SerializeField] float _MoveMaxPower = 10;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(v > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
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
