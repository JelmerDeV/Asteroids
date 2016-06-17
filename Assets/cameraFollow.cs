using UnityEngine;
using System.Collections;

public class FollowTarget3 : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;

	private Vector3 velocity = Vector3.zero;

	void Update () {
		Vector3 goalPosX = target.position;
		goalPosX.x = transform.position.x;


		transform.position = Vector3.SmoothDamp (transform.position, goalPosX, ref velocity, smoothTime);
	}
}