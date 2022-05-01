using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy = default;
    public void Spawn()
    {
        var enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        Destroy(gameObject);
    }
}
