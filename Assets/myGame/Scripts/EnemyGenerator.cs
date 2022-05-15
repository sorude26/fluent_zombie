using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Perapera_Puroto
{
    public class EnemyGenerator : MonoBehaviour
    {
        [Tooltip("�G�o���n�_")]
        [SerializeField]
        private Transform[] _spawnPoints = default;
        [Tooltip("�G��Prefab")]
        [SerializeField]
        private GameObject[] _enemyPrefab = default;
        [Tooltip("�o������")]
        [SerializeField]
        private float _spawnTime = 2f;

        [Tooltip("���x�㏸�o����")]
        [SerializeField]
        private int _speedUpCount = 10;
        [Tooltip("�o�����x�㏸���x")]
        [SerializeField]
        private float _speedUpSpeed = 1.1f;
        private float _spawnSpeed = 1f;
        /// <summary> �N���t���O </summary>
        private bool _isStart = false;
        int _number;
        /// <summary>
        /// �����_���ȏo���ʒu�ɓG���X�|�[��������
        /// </summary>
        private void SpawnEnemy()
        {
            int r = Random.Range(0, _spawnPoints.Length);
            _number = Random.Range(0, _enemyPrefab.Length);
            Instantiate(_enemyPrefab[_number], _spawnPoints[r]);
        }
        private IEnumerator GeneratorUpdate()
        {
            float timer = _spawnTime;
            int count = _speedUpCount;
            while (_isStart)
            {
                timer -= _spawnSpeed * Time.deltaTime;
                if (timer <= 0)
                {
                    timer = _spawnTime;
                    SpawnEnemy();
                    count--;
                    if (count <= 0)//�J�E���g���Ƃɑ��x�㏸������
                    {
                        count = _speedUpCount;
                        _spawnSpeed *= _speedUpSpeed;
                    }
                }
                yield return null;
            }
        }
        /// <summary>
        /// �G�̃X�|�[�����J�n����
        /// </summary>
        public void StartGenerator()
        {
            if (_isStart)
            {
                return;
            }
            _isStart = true;
            StartCoroutine(GeneratorUpdate());
        }
        /// <summary>
        /// �G�̃X�|�[�����~����
        /// </summary>
        public void StopGenerator()
        {
            _isStart = false;
        }
    }
}