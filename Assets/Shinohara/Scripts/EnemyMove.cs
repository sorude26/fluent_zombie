using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")] float _moveSpeed = 3f;
    
    NavMeshAgent _agent = default;
    GameObject _player = default;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
        _agent.SetDestination(_player.transform.position);
        _agent.speed = _moveSpeed;
        _agent.updateRotation = false;  //‰ñ“]‚ð‚³‚¹‚È‚¢
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
