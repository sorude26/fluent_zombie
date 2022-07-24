using System;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    [SerializeField]
    private int _maxHitCount = 1;
    [SerializeField]
    private string _hitTag = "Player";
    [SerializeField]
    private ParticleSystem _hitEffect = default;
    public event Action OnHit;
    private int _hitCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _hitTag)
        {
            _hitCount++;
            if (_hitEffect is not null)
            {
                _hitEffect.Play();
            }
            if (_hitCount >= _maxHitCount)
            {
                _hitCount = 0;
                OnHit?.Invoke();
            }
        }
    }
}
