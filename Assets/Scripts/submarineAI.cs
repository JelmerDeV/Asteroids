using UnityEngine;
using System.Collections;

public class submarineAI : MonoBehaviour {
	public Transform target; 
	public float moveSpeed = 5; 
	public float rotationSpeed = 0; 

	GameObject _playerGameObject;

	public Transform myTransform;



	void Awake()
	{
		_playerGameObject = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		target = GameObject.FindWithTag("Player").transform;
	}



	void Update () {




			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		myTransform.position += myTransform.up * moveSpeed * Time.deltaTime;


       

		}
		



	void state2(){

	}
		
	void OnTriggerEnter(Collider other)
	{
		
		}

    }
