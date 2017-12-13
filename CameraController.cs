using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	void FixedUpdate () 
	{
		Vector3 desiredPosition = target.position + offset;
		transform.position = desiredPosition;
	}
}
