using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform player;
	public Vector3 offset;

	void LateUpdate () 
	{
		transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);
	}

}