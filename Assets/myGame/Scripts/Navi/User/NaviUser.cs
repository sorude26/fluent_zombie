using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class NaviUser : MonoBehaviour
{
    [SerializeField]
    private Transform[] _targets = default;
    [SerializeField]
    private float _naviInterval = 1f;
    [SerializeField]
    private float _moveSpeed = 1f;
    [SerializeField]
    private Transform _body = default;
    private Vector3 _currentDir = Vector3.zero;
    private Rigidbody _rb = default;
    private float _timer = 0f;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _timer = _naviInterval;
        if (_body is null)
        {
            _body = transform;
        }
        foreach (Transform target in _targets)
        {
            NavigationManager.Instance.RequestTargetNavigation(target);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _naviInterval)
        {
            _timer = 0;
            int point = 0;
            Transform topTarget = null;
            foreach (Transform target in _targets)
            {
                var p = NavigationManager.Instance.GetPoint(_body, target.gameObject.name);
                if (p > point)
                {
                    point = p;
                    topTarget = target;
                }
            }
            if (topTarget is not null)
            {
                _currentDir = NavigationManager.Instance.GetMoveDir(_body, topTarget.gameObject.name);
            }
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = _currentDir * _moveSpeed;
    }
}
