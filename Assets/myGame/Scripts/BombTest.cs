using UnityEngine;

namespace Perapera_Puroto
{
    public class BombTest : MonoBehaviour
    {
        [SerializeField, Tooltip("�����ʒu")]
        Transform _muzzle = default;
        [SerializeField, Tooltip("������")]
        GameObject _bomb = default;

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