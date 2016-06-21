using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnMovement : MonoBehaviour
{
	AudioSource Bite;
	public AudioSource pickupAudio;
	public AudioSource explodeAudio;
	private bool Vooruit = false;
    private bool Rechts = false;
    private bool Links = false;
    private float turnRight = 0;
    private float turnLeft = 0;
    private float thrust = 0;
    private float maxThrust = 5;
	private bool Speed_ = false;
	private bool Invincible_ = false;
	private int scoreMultiplier = 10;
	public static float lives = 3f;
	private int gameScore;
	private int highScore;
	public Text scoreText;
	public Text highScoreText;
	public Text SpeedText;
	public Text PowerText;
    void Start()
    {
		Bite = GetComponent (typeof(AudioSource)) as AudioSource;
		PowerText.color = Color.grey;
		SpeedText.color = Color.grey;
		UpdateUI ();
    }

	/*void FixedUpdate(){
		if (lives == 0f) {
			GameOver ();

		}
	}*/

	void GameOver(){
		Destroy (gameObject);

	}

    void Update()
    {
		

		if (Speed_) {
			maxThrust = 30;
		} else if (!Speed_) {
			maxThrust = 15;
		}
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
			Bite.Play ();
            Destroy(other.gameObject);
			gameScore += scoreMultiplier;
			UpdateUI ();
			//Debug.Log (gameScore);

        }

		if (other.tag == "torpedo") {
			explodeAudio.Play ();
			if (!Invincible_) {
				lives--;
			}
			Debug.Log (lives);
		}
		if (other.tag == "pickupSpeed") {
			pickupAudio.Play ();
			Speed_ = true;
			SpeedText.color = Color.green;
			InvokeRepeating ("powerup", 5, 0);
			Destroy (other.gameObject);
		}
		if (other.tag == "pickupPower") {
			pickupAudio.Play ();
			Invincible_ = true;
			PowerText.color = Color.green;
			InvokeRepeating ("powerup2", 10, 0);
			Destroy (other.gameObject);
		}
    }

	void powerup(){
		Speed_ = false;
		SpeedText.color = Color.grey;
	}

	void powerup2(){
		Invincible_ = false;
		PowerText.color = Color.grey;
	}

	void UpdateUI()
	{
		if (gameScore > highScore) {
			highScore = gameScore;
		}
		scoreText.text = "Score: " + gameScore;
		highScoreText.text = "Highscore: " + highScore;
		SpeedText.text = "Speed pickup";

		PowerText.text = "Invincibility";

	}
}
