using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPManager
{
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            PlayerHP();
            StartCoroutine(NoDamagiTime());
        }
    }

    IEnumerator NoDamagiTime()
    {
        Debug.Log( "Fast:" +_noDamagiBool);
        yield return new WaitForSeconds(_noDamagiTime);
        _noDamagiBool = false;
        Debug.Log( "Second:" + _noDamagiBool);
    }
}
