using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogPlatform : MonoBehaviour {

    GameObject boundaryCube;

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject controller;
    Controller controllerScript;

    public float level = 0;
    public float speed = 1;
    float originalSpeed;

    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        originalSpeed = speed;
        originalPos = transform.position;

        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        boundaryCube = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		if(level != golfBallScript.currentLevel) { return; }
        float step = speed * Time.deltaTime;
        Vector3 newLoc = new Vector3(originalPos.x + controllerScript.rightAnalogX * boundaryCube.transform.localScale.x / 2, originalPos.y, originalPos.z + controllerScript.rightAnalogY * boundaryCube.transform.localScale.z / 2);
        transform.position = Vector3.MoveTowards(transform.position, newLoc, step);
	}
}
