using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;

	private Vector3 velocity = Vector3.zero;

	void Update () {
		Vector3 goalPosY = target.position;
		goalPosY.y = transform.position.y;

		Vector3 goalPosX = target.position;
		goalPosY.x = transform.position.x;



		transform.position = Vector3.SmoothDamp (transform.position, goalPosY, ref velocity, smoothTime);
		transform.position = Vector3.SmoothDamp (transform.position, goalPosX, ref velocity, smoothTime);
	}
}