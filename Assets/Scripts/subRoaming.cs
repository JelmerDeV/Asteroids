using UnityEngine;
using System.Collections;

public class subRoaming: MonoBehaviour {
	public float speed = 1f;
	public float rotateL;
	public float rotateR;
	public float timer;
	void Start () {
		timer = Random.Range (2f, 5f);
		speed = Random.Range (1.0f, 8.0f);
		rotateL = Random.Range (0f, 100f);
		rotateR = Random.Range (0f, 100f);
		InvokeRepeating ("move", 0, timer);
		//Debug.Log (timer);

	}

	void Update () {

		transform.Translate (Vector3.up * Time.deltaTime * speed);
		transform.Rotate (Vector3.forward * Time.deltaTime * rotateL);
		transform.Rotate (Vector3.back * Time.deltaTime * rotateR);
	}

	void move(){
		rotateL = Random.Range (0f, 100f);
		rotateR = Random.Range (0f, 100f);
		speed = Random.Range (1.0f, 8.0f);
		timer = Random.Range (0.5f, 1.5f);
	}
	void OnTriggerEnter(Collider other)
	{
		
	}

}
