using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    LineRenderer line;


    // Start is called before the first frame update
    [SerializeField]
    float _xMax = 0;
    [SerializeField]
    float _xMin = 0;
    [SerializeField]
    float _zMax = 0;
    [SerializeField]
    float _zMin = 0;

    [SerializeField]
    float _yPos = 0;

    [SerializeField] GameObject a;

    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    [SerializeField] GameObject four;

    void Start()
    {
        line = one.GetComponent<LineRenderer>();

        a.transform.position = SpawnPos();
        StartCoroutine("A");
    }

    // Update is called once per frame
    void Update()
    {
        one.transform.position = new Vector3(_xMax, _yPos, _zMax);
        two.transform.position = new Vector3(_xMax, _yPos, _zMin);
        three.transform.position = new Vector3(_xMin, _yPos, _zMin);
        four.transform.position = new Vector3(_xMin, _yPos, _zMax);

        //line.SetPosition(0, one.transform.position);
        //line.SetPosition(1, two.transform.position);
        //line.SetPosition(2, three.transform.position);
        //line.SetPosition(3, one.transform.position);


        var positions = new Vector3[]{
        one.transform.position,               // 開始点
        two.transform.position,               // 終了点
        three.transform.position,
        four.transform.position,
        one.transform.position,
    };

        // 線を引く場所を指定する
        line.SetPositions(positions);
    }
    IEnumerator A()
    {
        a.transform.position = SpawnPos();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("A");
    }

    private Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(_xMin, _xMax), _yPos, Random.Range(_zMin, _zMax));
    }
}
