using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPManager
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            PlayerHP();
        }
    }
}
