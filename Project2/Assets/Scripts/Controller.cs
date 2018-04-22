using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public GameObject pauseManager;
    PauseMenu pauseMenuScript;

    float hInput = 0;
    float vInput = 0;

    public float rightAnalogX;
    public float rightAnalogY;

    public float LTInput = 0;
    public float RTInput = 0;

    int numPlayers = 1;

    public bool p1_isXbox = true;
    public bool p2_isXbox = true;

	// Use this for initialization
	void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        pauseMenuScript = pauseManager.GetComponent<PauseMenu>();

        numPlayers = PlayerPrefs.GetInt("Players");

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                if(x == 0)
                {
                    Debug.Log("P1 is PS4");
                    p1_isXbox = false;
                }
                else if(x == 1)
                {
                    Debug.Log("P2 is PS4");
                    p2_isXbox = false;
                }
                
            }
            if (names[x].Length == 33)
            {
                if (x == 0)
                {
                    Debug.Log("P1 is Xbox");
                }
                else if (x == 1)
                {
                    Debug.Log("P2 is Xbox");
                }

            }
        }
    }

    // Update is called once per frame
    void Update() {
        if(pauseMenuScript.isPaused)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            //Application.Quit();
        }
        if (Input.GetButtonDown("P1_A"))//if they press the A button
        {
            float intensity = Mathf.Max(hInput, vInput);//the force to putt the ball, based on how tilted the analog stick was
            //ballScript.Putt(intensity);
        }
        if (Input.GetButtonDown("Reset") && p1_isXbox)
        {
            golfBallScript.ResetBall();
        }
        if (Input.GetButtonDown("ResetP") && !p1_isXbox)
        {
            golfBallScript.ResetBall();
        }
        if (Input.GetButtonDown("Start"))
        {
            //golfBallScript.ReturnToSelect();
        }
        if (numPlayers == 1)
        {
            if(p1_isXbox)
            {
                LTInput = Input.GetAxis("P1LT");
                RTInput = Input.GetAxis("P1RT");
                rightAnalogX = Input.GetAxis("P1RightHor");
                rightAnalogY = -Input.GetAxis("P1RightVert");
            }
            if (!p1_isXbox)
            {
                LTInput = Input.GetAxis("P1LTP");
                RTInput = Input.GetAxis("P1RTP");
                rightAnalogX = Input.GetAxis("P1RightHorP");
                rightAnalogY = -Input.GetAxis("P1RightVertP");
            }
        }
        else if (numPlayers == 2)
        {
            if(p2_isXbox)
            {
                LTInput = Input.GetAxis("P2LT");
                RTInput = Input.GetAxis("P2RT");
                rightAnalogX = Input.GetAxis("P2RightHor");
                rightAnalogY = -Input.GetAxis("P2RightVert");
            }
            if(!p2_isXbox)
            {
                LTInput = Input.GetAxis("P2LTP");
                RTInput = Input.GetAxis("P2RTP");
                rightAnalogX = Input.GetAxis("P2RightHorP");
                rightAnalogY = -Input.GetAxis("P2RightVertP");
            }
        }
    }
    public bool B_Down()
    {
        if(numPlayers == 2)
        {
            if (Input.GetButton("P2_B") && p2_isXbox)
            {
                return true;
            }
            if (Input.GetButton("P2_X") && !p2_isXbox)
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_B") && p1_isXbox)
            {
                return true;
            }
            if (Input.GetButton("P1_X") && !p1_isXbox)
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
            if (Input.GetButton("P2_Y") && p2_isXbox)
            {
                return true;
            }
            if (Input.GetButton("P2_Y") && !p2_isXbox)
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_Y") && p1_isXbox)
            {
                return true;
            }
            if (Input.GetButton("P1_Y") && !p1_isXbox)
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
            if (Input.GetButton("P2_X") && p2_isXbox)
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Input.GetButton("P1_X") && p1_isXbox)
            {
                return true;
            }
            else return false;
        }
    }
}
