using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	const int ROTATE_SPPED = 5;
	
	void Update()
	{
		var look = Camera.main.transform.forward;
		look.y = 0;
		transform.forward = Vector3.Lerp(transform.forward, look, ROTATE_SPPED * Time.deltaTime);
	}
}
