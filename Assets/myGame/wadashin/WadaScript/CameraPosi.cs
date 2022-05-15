using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosi : MonoBehaviour
{
    /// <summary>Player</summary>
    [SerializeField] GameObject _Player;

    /// <summary>�J�����̈ʒu������</summary>
    [SerializeField] float _posX;
    /// <summary>�J�����̈ʒu���c��</summary>
    [SerializeField] float _posY;
    /// <summary>�J�����̈ʒu������</summary>
    [SerializeField] float _posZ;

    /// <summary>�J�����̊p�x���㉺��</summary>
    [SerializeField] float _rotateX;
    /// <summary>�J�����̊p�x�����E��</summary>
    [SerializeField] float _rotateY;

    void Start()
    {
        transform.position = _Player.transform.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_Player.transform.position.x + _posX, _Player.transform.position.y + _posY, _Player.transform.position.z - _posZ);
        this.transform.rotation = Quaternion.Euler(_rotateX, _rotateY,0);
    }
}
