using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perapera_Puroto
{
    public class PlayerHP : HPManager
    {
        private void Start()
        {
            UpdateHP();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                PlayerHP();
                StartCoroutine(NoDamagiTime());
            }
        }

        IEnumerator NoDamagiTime()
        {
            yield return new WaitForSeconds(_noDamagiTime);
            _noDamagiBool = false;
        }
    }
}
