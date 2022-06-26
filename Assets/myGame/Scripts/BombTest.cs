using UnityEngine;

namespace Perapera_Puroto
{
    public class BombTest : MonoBehaviour
    {
        [SerializeField, Tooltip("ê∂ê¨à íu")]
        Transform _muzzle = default;
        [SerializeField, Tooltip("ê∂ê¨å≥")]
        GameObject _bomb = default;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject go = Instantiate(_bomb, _muzzle.position, Quaternion.identity);
                go.GetComponent<Bomb>().AddForce(transform.forward);
            }
        }
    }
}