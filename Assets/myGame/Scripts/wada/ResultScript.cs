using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class ResultScript : MonoBehaviour
    {
        /// <summary>�ςݏグ�鎀�̂̃I�u�W�F�N�g</summary>
        [SerializeField]
        GameObject _dethObj = default;

        /// <summary>�ςݏグ�鐔</summary>
        [SerializeField]
        int num;

        /// <summary>�ςݏグ�ɂ����鎞��</summary>
        [SerializeField]
        int stackTime = 1;

        public float speed = 1.0F;

        float now = 0;

        float nowCadaver = 0;

        //�ςݏグ�鎀�̂̌���
        float high;
        //�I�u�W�F�N�g�����ꏊ
        Vector3 posi = default;
        //�ςݏグ�̍Œ�n�_�ƍō��n�_
        Vector3 lowPosi;
        Vector3 topPosi;

        //���̂�ςݏグ��ŏ��̍��W
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
