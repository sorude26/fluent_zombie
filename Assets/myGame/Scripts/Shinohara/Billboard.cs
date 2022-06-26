using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Billboard : MonoBehaviour
{
	[SerializeField] CinemachineVirtualCamera _camera;
	const int ROTATE_SPPED = 5;
	
	void Update()
	{
		var look = _camera.transform.forward;
		look.y = 0;
		transform.forward = Vector3.Lerp(transform.forward, look, ROTATE_SPPED * Time.deltaTime);
	}
}
