using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy = default;
    [SerializeField]
    private float _maxAwakeTime = 2f;
    private Animator _animator;
    private IEnumerator Start()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        float time = Random.Range(0, _maxAwakeTime);
        yield return new WaitForSeconds(time);
        _animator.enabled = true;
    }
    public void Spawn()
    {
        var enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        Destroy(gameObject);
    }
}
