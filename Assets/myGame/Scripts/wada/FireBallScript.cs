using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class FireBallScript : MonoBehaviour
    {

        //ファイヤーボールの速度
        [SerializeField]
        float _power;
        //発射角度のランダム値上限
        [SerializeField]
        int _randomMax;
        //発射角度のランダム値下限
        [SerializeField]
        int _randomMin;
        //玉が消えるまでの時間
        [SerializeField]
        float deleteTime;


        private float time;
        //発射角度のランダム値
        private int randomX;
        private int randomY;
        private int randomZ;
        private GameObject _player;

        Rigidbody _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        /// <summary>弾を打つ </summary>
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
            if (time >= deleteTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
