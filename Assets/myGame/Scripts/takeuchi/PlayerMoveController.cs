using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 2f;
    private Rigidbody _rigidbody;
    private float _g = -0.5f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 dir = (Vector3.right * PlayerInput.InputVector.x + Vector3.forward * PlayerInput.InputVector.y).normalized * _moveSpeed;
        dir.y = _rigidbody.velocity.y + _g;
        _rigidbody.velocity = dir;
    }
}
