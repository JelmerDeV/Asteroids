using UnityEngine;
using System.Collections;

public class torpedoShooting : MonoBehaviour {

	public Rigidbody projectile;

	private float speed = 0f;
	public float spawnRate = 5f;
	public float startSpawn = 5f;
	//private float nextFire = 0.0F;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawn", startSpawn, spawnRate);
	}

	// Update is called once per frame


	void spawn()
	{
		spawnRate = 5f;
		//nextFire = Time.time + spawnRate;

		Rigidbody instantiatedProjectile = Instantiate (projectile,
			transform.position,
			transform.rotation)
			as Rigidbody;

		instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));


	}
}