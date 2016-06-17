﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnMovement : MonoBehaviour
{
    public bool Vooruit = false;
    public bool Rechts = false;
    public bool Links = false;
    private float turnRight = 0;
    private float turnLeft = 0;
    private float thrust = 0;
    public float maxThrust = 5;
	private int gameScore;
	private int highScore;
	public Text scoreText;
	public Text highScoreText;
    void Start()
    {
		UpdateCounterUI ();
    }

    void Update()
    {
		//Debug.Log (thrust);
        transform.Translate(Vector3.up* Time.deltaTime * thrust);
        transform.Rotate(Vector3.forward * Time.deltaTime * turnLeft);
		transform.Rotate(Vector3.back * Time.deltaTime * turnRight);


        if (thrust < 0.1)
        {
            turnRight = 0;
            turnLeft = 0;
        }

        if (Input.GetKey("right") && thrust > 0.1)
        {
            Rechts = true;
            if (Rechts && turnRight < 200)
            {
                turnLeft = 0;
                turnRight += 5f;
                //Debug.Log(turnRight);
            }
            //transform.Rotate (Vector3.up * Time.deltaTime * turnRight);
        }
        if (Input.GetKeyUp("right"))
        {
            Rechts = false;

        }

        if (Input.GetKey("left") && thrust > 0.1)
        {
            Links = true;
            if (Links == true && turnLeft < 200)
            {
                turnRight = 0;
                turnLeft += 5f;
                //Debug.Log(turnLeft);
            }
            //transform.Rotate (Vector3.down * Time.deltaTime * turnLeft);
        }
        if (Input.GetKeyUp("left"))
        {
            Links = false;

        }

        if (Input.GetKey("space"))
        {
            Vooruit = true;
            if (Vooruit == true && thrust < maxThrust)
            {
                thrust += 0.2f;
            }
            //transform.Translate (Vector3.forward * Time.deltaTime * thrust);
        }

        if (Input.GetKeyUp("space"))
        {
            Vooruit = false;
        }

        if (thrust > 0)
        {
            thrust -= 0.05f;
        }
        if (Rechts == false && turnRight > 0)
        {
            turnRight -= 2.5f;
        }
        if (Links == false && turnLeft > 0)
        {
            turnLeft -= 2.5f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "fish")
        {
            Destroy(other.gameObject);
			gameScore += 10;
			UpdateCounterUI ();
			//Debug.Log (gameScore);

        }
    }

	void UpdateCounterUI()
	{
		if (gameScore > highScore) {
			highScore = gameScore;
		}
		scoreText.text = "Score: " + gameScore;
		highScoreText.text = "Highscore: " + highScore;

	}
}
