using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float _xMax = 0;
    [SerializeField]
    float _xMin = 0;
    [SerializeField]
    float _zMax = 0;
    [SerializeField]
    float _zMin = 0;

    [SerializeField]
    float _yPos = 0;

    private Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(_xMin, _xMax), _yPos, Random.Range(_zMin, _zMax));
    }
}
