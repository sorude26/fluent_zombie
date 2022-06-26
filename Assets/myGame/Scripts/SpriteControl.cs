using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControl : MonoBehaviour
{
    void Start()
    {
        var r = GetComponent<SpriteRenderer>();
        r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        r.receiveShadows = true;
    }

}
