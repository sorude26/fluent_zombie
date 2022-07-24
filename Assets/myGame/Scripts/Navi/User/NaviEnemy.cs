using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class NaviEnemy : MonoBehaviour
{
    [SerializeField]
    private float _naviInterval = 1f;
    [SerializeField]
    private float _moveSpeed = 1f;
    [SerializeField]
    private Transform _body = default;
    private Vector3 _currentDir = Vector3.zero;
    [SerializeField]
    private Rigidbody _rb = default;
    private float _timer = 0f;
    private bool _isMove = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _timer = _naviInterval;
        if (_body is null)
        {
            _body = transform;
        }
    }

    private void Update()
    {
        if (!_isMove) { return; }
        _timer += Time.deltaTime;
        if (_timer > _naviInterval)
        {
            _timer = 0;
            _currentDir = NavigationManager.Instance.GetMoveDir(_body);           
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = _currentDir * _moveSpeed;
    }
    public void StartMove()
    {
        _isMove = true;
    }
    private void OnDisable()
    {
        _isMove = false;
        _currentDir = Vector3.zero;
        _rb.velocity = Vector3.zero;
    }
}
