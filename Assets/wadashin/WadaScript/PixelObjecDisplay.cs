using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObjectDisplay : MonoBehaviour
{
    private Vector3 cashPosition;
    /// <summary>�h�b�g��1�h�b�g��������</summary>
    void LateUpdate()
    {
        cashPosition = transform.localPosition;
        //�����_�ȉ��l�̌ܓ�
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
