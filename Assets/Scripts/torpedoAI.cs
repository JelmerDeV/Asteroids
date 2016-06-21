using UnityEngine;
using System.Collections;

public class torpedoAI : MonoBehaviour {

	public Transform target; 
	public float moveSpeed = 8f; 
	public float rotationSpeed = 3f; 
	private float stopTime = 8f;

	private bool slowDown = false;
	GameObject _playerGameObject;
	public Transform myTransform; 


	void Awake()
	{
		_playerGameObject = GameObject.FindGameObjectWithTag ("Player");
	}



	void Start ()
	{

		target = GameObject.FindWithTag("Player").transform; 

		InvokeRepeating ("torpedoStop", 7, stopTime);

	}


	void Update ()
	{

		if (slowDown == true && moveSpeed > 0 ){

			moveSpeed -= 0.05f;
		}
		if (moveSpeed < 0.1) {
			Destroy (gameObject, 0f);
		}
		if (slowDown == false) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}






	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Destroy (gameObject, 0f);

		}


	}

	void torpedoStop(){
		slowDown = true;
	}

}