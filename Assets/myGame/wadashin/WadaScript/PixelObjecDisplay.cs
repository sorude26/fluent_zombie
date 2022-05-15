using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObjectDisplay : MonoBehaviour
{
    private Vector3 cashPosition;
    /// <summary>ドットを1ドットずつ動かす</summary>
    void LateUpdate()
    {
        cashPosition = transform.localPosition;
        //小数点以下四捨五入
        transform.localPosition = new Vector3(
                        Mathf.RoundToInt(cashPosition.x),
                        Mathf.RoundToInt(cashPosition.y),
                        Mathf.RoundToInt(cashPosition.z)
                   );
    }

    void OnRenderObject()
    {
        transform.localPosition = cashPosition;
    }
}
