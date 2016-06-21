using UnityEngine;
using System.Collections;

public class life1 : MonoBehaviour {

	public int LeverPoint;

	// Use this for initialization
	void Start () {
		GameObject thePlayer = GameObject.Find("player");
		TurnMovement turnMovement = thePlayer.GetComponent<TurnMovement>();

	}
	
	// Update is called once per frame
	void Update () {
		if (TurnMovement.lives < LeverPoint) {
			Destroy (gameObject, 0f);
		}
	}
}
