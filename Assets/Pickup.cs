using UnityEngine;
using System.Collections;


public class Pickup : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * Time.deltaTime * 15);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			
			//Destroy (gameObject);

		}
	}
}
