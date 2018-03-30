using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GolfBall ballScript;
    public GameObject golfBall;

    float hInput = 0;
    float vInput = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            hInput = -Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            vInput = Input.GetAxis("Vertical");
        }
        ballScript.RotateBall(hInput, vInput);

        if (Input.GetButtonDown("P1_A"))//if they press the A button
        {
            float intensity = Mathf.Max(hInput, vInput);//the force to putt the ball, based on how tilted the analog stick was
            ballScript.Putt(intensity);
        }
    }
}
