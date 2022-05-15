using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    Transform _followTarget = default;
    [SerializeField]
    Transform _rotationTarget = default;
    [SerializeField]
    float _followSpeed = 1f;
    [SerializeField]
    float _rotationSpeed = 1f;
    private void FixedUpdate()
    {
        if (_followTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.forward = Vector3.Lerp(transform.forward, _rotationTarget.forward, _rotationSpeed * Time.deltaTime);
        float speed = (transform.position - _followTarget.position).sqrMagnitude;
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, speed * _followSpeed * Time.deltaTime);
    }
}
