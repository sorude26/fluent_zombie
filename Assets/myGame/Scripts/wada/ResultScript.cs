using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class ResultScript : MonoBehaviour
    {
        /// <summary>積み上げる死体のオブジェクト</summary>
        [SerializeField]
        GameObject _dethObj = default;

        /// <summary>積み上げる数</summary>
        [SerializeField]
        int num;

        /// <summary>積み上げにかける時間</summary>
        [SerializeField]
        int stackTime = 1;

        public float speed = 1.0F;

        float now = 0;

        float nowCadaver = 0;

        //積み上げる死体の厚み
        float high;
        //オブジェクト生成場所
        Vector3 posi = default;
        //積み上げの最低地点と最高地点
        Vector3 lowPosi;
        Vector3 topPosi;

        //死体を積み上げる最初の座標
        Vector3 cadaverPos;



        void Start()
        {
            high = _dethObj.transform.localScale.y;
            //lowPosi = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //topPosi = new Vector3(this.transform.position.x, this.transform.position.y + (high * (num)), this.transform.position.z);

            cadaverPos = new Vector3(this.transform.position.x,this.transform.position.y + 3,this.transform.position.z);

            float stuckInterval = (float)stackTime / (float)num;
            InvokeRepeating("StackDeth", 0, stuckInterval);
        }
        void Update()
        {
            //var t = Time.time / stackTime;
            //posi = Vector3.Lerp(lowPosi, topPosi, t);


            //if (posi.y >= now)
            //{
            //    Instantiate(_dethObj, posi, Quaternion.identity);
            //    now += high;
            //}


            if (nowCadaver >= num)
            {
                CancelInvoke();
            }
        }

        //void StackDeth()
        //{
        //    Instantiate(_dethObj, posi, Quaternion.identity);
        //    now += high;
        //}

        void StackDeth()
        {
            Instantiate(_dethObj, cadaverPos, Quaternion.identity);
            cadaverPos.y += high;
            nowCadaver++;
        }
    }
}
