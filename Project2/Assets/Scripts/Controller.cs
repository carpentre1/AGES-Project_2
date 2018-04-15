using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    float hInput = 0;
    float vInput = 0;

    public float rightAnalogX;
    public float rightAnalogY;

    public float LTInput = 0;

    int numPlayers = 1;

	// Use this for initialization
	void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("P1_A"))//if they press the A button
        {
            float intensity = Mathf.Max(hInput, vInput);//the force to putt the ball, based on how tilted the analog stick was
            //ballScript.Putt(intensity);
        }
        if (Input.GetButtonDown("Reset"))
        {
            golfBallScript.ResetBall();
        }
        if (Input.GetButtonDown("Start"))
        {
            golfBallScript.ReturnToSelect();
        }
        if (numPlayers == 1)
        {
            LTInput = Mathf.Max(Input.GetAxis("P1LT"), Input.GetAxis("P2LT"));
            rightAnalogX = Input.GetAxis("P1RightHor");
            rightAnalogY = -Input.GetAxis("P1RightVert");
            Debug.Log(rightAnalogX);
        }
        else if (numPlayers == 2)
        {
            LTInput = Input.GetAxis("P2LT");
            rightAnalogX = Input.GetAxis("P2RightHor");
            rightAnalogY = -Input.GetAxis("P2RightVert");
        }
    }
    public bool B_Down()
    {
        if(numPlayers == 2)
        {
            if (Input.GetButton("P2_B"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_B") || Input.GetButton("P2_B"))
            {
                return true;
            }
            else return false;
        }
    }
    public bool Y_Down()
    {
        if (numPlayers == 2)
        {
            if (Input.GetButton("P2_Y"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_Y") || Input.GetButton("P2_Y"))
            {
                return true;
            }
            else return false;
        }
    }
    public bool X_Down()
    {
        if (numPlayers == 2)
        {
            if (Input.GetButton("P2_X"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_X") || Input.GetButton("P2_X"))
            {
                return true;
            }
            else return false;
        }
    }
}
