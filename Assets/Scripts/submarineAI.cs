using UnityEngine;
using System.Collections;

public class submarineAI : MonoBehaviour {
	public Transform target; 
	public float moveSpeed = 0; 
	public float rotationSpeed = 0; 
	private bool sight = false;
	private bool onState1 = false;

	GameObject _playerGameObject;

	public Transform myTransform;



	void Awake()
	{
		_playerGameObject = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		
	}



	void Update () {

		//Debug.Log (sight);

		//if (onState1 == true) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		//}

        //Debug.Log (sight);
       
		if (onState1 == true) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            sight = false;
        }

		}
		


	void state1(){

		//moveSpeed = 4;
		rotationSpeed = 1;
		target = GameObject.FindWithTag("Player").transform;
	}

	void state2(){

	}
		
	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "sphereCollider") {
			
			onState1 = true;
			state1();
			//Debug.Log (sight);
		}

    }
}