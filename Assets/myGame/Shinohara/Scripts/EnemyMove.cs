using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("移動速度")] float _moveSpeed = 3f;
    
    NavMeshAgent _agent = default;
    GameObject _player = default;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.transform.position);
        }
    }
}
