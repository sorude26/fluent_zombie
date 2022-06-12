using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy = default;
    [SerializeField]
    private float _maxAwakeTime = 5f;
    [SerializeField]
    private Animator _animator;
    private void OnEnable()
    {
        StartCoroutine(StartSpawn());
    }
    private IEnumerator StartSpawn()
    {
        _animator = GetComponent<Animator>();
        float time = Random.Range(0, _maxAwakeTime);
        yield return new WaitForSeconds(time);
        _animator.Play("Spawn");
    }
    public void Spawn()
    {
        ObjectPoolManager.Instance.Use(_enemy,transform.position);
        gameObject.SetActive(false);
    }
}
