using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Perapera_Puroto
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemy = default;
        [SerializeField]
        private float _maxAwakeTime = 5f;
        [SerializeField]
        private Animator _animator;
        private IEnumerator Start()
        {
            _animator = GetComponent<Animator>();
            float time = Random.Range(0, _maxAwakeTime);
            yield return new WaitForSeconds(time);
            _animator.Play("Spawn");
        }
        public void Spawn()
        {
            var enemy = Instantiate(_enemy);
            enemy.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}