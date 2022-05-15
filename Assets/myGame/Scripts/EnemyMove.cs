using UnityEngine;
using UnityEngine.AI;

namespace Perapera_Puroto
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField, Header("�ړ����x")]
        float _moveSpeed = 3f;
        /// <summary>�v���C���[��ǂ�������i�r���b�V�� </summary>
        NavMeshAgent _agent = default;
        /// <summary>�v���C���[ </summary>
        GameObject _player = default;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();

            if (GameObject.Find("Player") != null)  //�v���C���[�����݂���Ύ擾����
            {
                _player = GameObject.Find("Player");
                _agent.SetDestination(_player.transform.position);
            }

            _agent.speed = _moveSpeed;
            _agent.updateRotation = false;  //��]�������Ȃ�
        }

        void Update()
        {
            if (_player != null)
            {
                _agent.SetDestination(_player.transform.position);
            }
        }
    }
}