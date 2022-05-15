using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 0, 2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, 0, -2);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-2, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(2, 0, 0);
        }
    }
}
