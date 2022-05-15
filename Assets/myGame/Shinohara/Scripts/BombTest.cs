using UnityEngine;

public class BombTest : MonoBehaviour
{
    [SerializeField] Transform _muzzle = default;
    [SerializeField] GameObject _bomb = default;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(_bomb, _muzzle.position, Quaternion.identity);
            go.GetComponent<Bomb>().AddForce(transform.forward);
        }

        
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.Rotate(0, -90, 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.Rotate(0, 90, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.Rotate(-20, 0, 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.Rotate(20, 0, 0);
        //}
    }
}
