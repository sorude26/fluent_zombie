using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    private float time;

    //���ˊp�x�̃����_���l
    private int randomX;
    private int randomY;
    private int randomZ;
    private GameObject _player;

    Rigidbody _rb;

    //�t�@�C���[�{�[���̑��x
    [SerializeField] float _power;

    //���ˊp�x�̃����_���l���
    [SerializeField] int _randomMax;
    //���ˊp�x�̃����_���l����
    [SerializeField] int _randomMin;
    //�ʂ�������܂ł̎���
    [SerializeField] float deleteTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void StartShot(Transform player)
    {
        randomX = Random.Range(_randomMin, _randomMax);
        randomY = Random.Range(_randomMin, _randomMax);
        randomZ = Random.Range(_randomMin, _randomMax);
        this.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x + randomX, player.transform.localEulerAngles.y + randomY, player.transform.localEulerAngles.z + randomZ);
    }
    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(transform.forward.normalized * _power, ForceMode.Impulse);

        time += Time.deltaTime;
        if(time >= deleteTime)
        {
            Destroy(this.gameObject);
        }
    }
}
