using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothTime;
	private Vector3 offset = new Vector3 ();
	private Vector3 _velocity = Vector3.zero;

	void Start()
	{
		offset = target.position + transform.position;
	}

	void LateUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		//transform.position = target.position - offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
	}
}