using UnityEngine;
using UnityEngine.AI;

namespace Perapera_Puroto
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField, Header("移動速度")]
        float _moveSpeed = 3f;
        /// <summary>プレイヤーを追いかけるナビメッシュ </summary>
        NavMeshAgent _agent = default;
        /// <summary>プレイヤー </summary>
        GameObject _player = default;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();

            if (GameObject.Find("Player") != null)  //プレイヤーが存在すれば取得する
            {
                _player = GameObject.Find("Player");
                _agent.SetDestination(_player.transform.position);
            }

            _agent.speed = _moveSpeed;
            _agent.updateRotation = false;  //回転をさせない
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