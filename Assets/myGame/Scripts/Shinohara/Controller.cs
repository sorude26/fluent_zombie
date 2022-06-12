using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Animator _anim = default;
    Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            var dir = new Vector3(h, 0, v).normalized * 8;
            _body.velocity = dir;
        }
        else
        {
            _body.velocity = Vector3.zero;
        }
       
        //if (Input.GetKey(KeyCode.S))
        //{
        //   // transform.Translate(0, 0, -0.03f);
        //    _anim.SetBool("Forward", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    _anim.SetBool("Forward", false);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //   // transform.Translate(-0.03f, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //   // transform.Translate(0.03f, 0, 0);
        //    _anim.SetBool("Right", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    _anim.SetBool("Right", false);
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //transform.Translate(0, 0, 0.03f);
        //    _anim.SetBool("Back", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.W))
        //{
        //    _anim.SetBool("Back", false);
        //}
    }
}
