using UnityEngine;
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
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * thrust);
        transform.Rotate(Vector3.down * Time.deltaTime * turnLeft);
        transform.Rotate(Vector3.up * Time.deltaTime * turnRight);


        if (thrust < 0.1)
        {
            turnRight = 0;
            turnLeft = 0;
        }

        if (Input.GetKey("right") && thrust > 0.1)
        {
            Rechts = true;
            if (Rechts == true && turnRight < 150)
            {
                turnLeft = 0;
                turnRight += 6f;
                Debug.Log(turnRight);
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
            if (Links == true && turnLeft < 150)
            {
                turnRight = 0;
                turnLeft += 6f;
                Debug.Log(turnLeft);
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
            thrust -= 0.050f;
        }
        if (Rechts == false && turnRight > 0)
        {
            turnRight -= 2f;
        }
        if (Links == false && turnLeft > 0)
        {
            turnLeft -= 2f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "fish")
        {
            Destroy(other.gameObject);
        }
    }
}
