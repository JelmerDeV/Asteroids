using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TorpedoShooting : MonoBehaviour {
	
	public Rigidbody projectile;

	private float speed = 0f;
	public int spawnRate = Random.Range (3, 15);
	public float startSpawn = 4f;



	// Use this for initialization
	void Start () {
		Debug.Log(spawnRate);
		InvokeRepeating ("spawn", startSpawn, spawnRate);
	}

	// Update is called once per frame

	void Update(){
		Debug.Log(spawnRate);
	}
	void spawn()
	{
		
		spawnRate = Random.Range (3, 15);

		Rigidbody instantiatedProjectile = Instantiate (projectile,
			transform.position,
			transform.rotation)
			as Rigidbody;

		instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, speed, 0));


	}
}