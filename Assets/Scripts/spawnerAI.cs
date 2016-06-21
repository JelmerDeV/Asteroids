using UnityEngine;
using System.Collections;

public class spawnerAI : MonoBehaviour {
	public float speed = 1f;
	public float rotateL;
	public float rotateR;
	public float timer;
	void Start () {
		timer = Random.Range (1f, 3f);
		speed = Random.Range (1.0f, 9.0f);
		rotateL = Random.Range (0f, 200f);
		rotateR = Random.Range (0f, 200f);
		InvokeRepeating ("move", 0, timer);
		Debug.Log (timer);

	}

	void Update () {

		transform.Translate (Vector3.up * Time.deltaTime * speed);
		transform.Rotate (Vector3.forward * Time.deltaTime * rotateL);
		transform.Rotate (Vector3.back * Time.deltaTime * rotateR);
	}

	void move(){
		rotateL = Random.Range (0f, 360f);
		rotateR = Random.Range (0f, 360f);
		speed = Random.Range (5.0f, 20.0f);
		timer = Random.Range (0.5f, 2f);
	}
	/*void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Destroy (gameObject, 0f);
		}
	}*/

}
