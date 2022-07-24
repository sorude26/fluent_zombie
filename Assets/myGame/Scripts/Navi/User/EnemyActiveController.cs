using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveController : MonoBehaviour
{
    [SerializeField]
    private float _maxAwakeTime = 5f;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private NaviEnemy _enemy = null;
    [SerializeField]
    private string[] _spawnAnime = {"Sleep","Fly" };
    [SerializeField]
    private string[] _getUpAnime = { "GetUp", "Fall" };
    [SerializeField]
    private string _endAnime = "FireEnd";
    [SerializeField]
    private HitChecker _hitChecker = null;
    private bool _isInstance = false;
    private void OnEnable()
    {
        if (!_isInstance)
        {
            _isInstance = true;
            _hitChecker.OnHit += () => { _animator.Play(_endAnime); };
            _animator = GetComponent<Animator>();
        }
        StartCoroutine(StartSpawn());
    }
    private IEnumerator StartSpawn()
    {
        float time = Random.Range(0, _maxAwakeTime);
        int r = Random.Range(0, _spawnAnime.Length);
        _animator.Play(_spawnAnime[r]);
        yield return new WaitForSeconds(time);
        _animator.Play(_getUpAnime[r]);
    }
    private void StartMove()
    {
        if (_enemy is not null)
        {
            _enemy.StartMove();
        }
    }
    private void DeadAction()
    {
        _enemy.gameObject.SetActive(false);
    }
}
