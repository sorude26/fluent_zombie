using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

namespace Perapera_Puroto
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField, Header("移動速度")]
        float _moveSpeed = 3f;
        private NavMeshAgent _agent = default;
        private GameObject _player = default;

        // Start is called before the first frame update
        void Start()
        {
            // _agent = GetComponent<NavMeshAgent>();
            _agent = gameObject.AddComponent<NavMeshAgent>();
            _agent.enabled = true;

            if (GameObject.Find("Player") != null)  //プレイヤーが存在すれば取得する
            {
                _player = GameObject.Find("Player");
                _agent.SetDestination(_player.transform.position);
            }

            _agent.speed = _moveSpeed;
            _agent.updateRotation = false;  //回転をさせない
        }

        // Update is called once per frame
        void Update()
        {
            if (_player != null)
            {
                _agent.SetDestination(_player.transform.position);
            }
        }
    }
}