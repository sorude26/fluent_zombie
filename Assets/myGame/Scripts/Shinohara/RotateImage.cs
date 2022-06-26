using UnityEngine;

public class RotateImage : MonoBehaviour
{
    Transform _cameraPosition;
    Quaternion _rotationValue;
    void Start()
    {
        _cameraPosition = GameObject.Find("CMVC1").GetComponent<Transform>();
        _rotationValue = Quaternion.Euler(_cameraPosition.localEulerAngles.x, 0f, 0);
        transform.rotation = _rotationValue;
    }

    private void Update()
    {
        _rotationValue =  Quaternion.Euler(_cameraPosition.localEulerAngles.x, 0f, 0);
        transform.rotation = _rotationValue;
    }
}
