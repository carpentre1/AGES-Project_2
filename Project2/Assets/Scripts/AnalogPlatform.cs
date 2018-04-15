using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogPlatform : MonoBehaviour {

    GameObject boundaryCube;

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject controller;
    Controller controllerScript;

    Color originalColor;

    public float level = 0;
    public float speed = 1;
    float originalSpeed;

    float currentX;
    float currentZ;

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
        originalColor = this.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
		if(level != golfBallScript.currentLevel) { return; }
        if (controllerScript.RTInput > .5)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.GetComponent<Renderer>().material.color = Color.black;
            return;
        }
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.GetComponent<Renderer>().material.color = originalColor;
        float deltaX = controllerScript.rightAnalogX;
        float deltaZ = controllerScript.rightAnalogY;
        float step = speed * Time.deltaTime;
        Vector3 newLoc = new Vector3(originalPos.x + controllerScript.rightAnalogX * boundaryCube.transform.localScale.x / 2, originalPos.y, originalPos.z + controllerScript.rightAnalogY * boundaryCube.transform.localScale.z / 2);
        transform.position = Vector3.MoveTowards(transform.position, newLoc, step);
        //float step = speed * Time.deltaTime;
        //Vector3 newLoc = new Vector3(originalPos.x + controllerScript.rightAnalogX * boundaryCube.transform.localScale.x / 2, originalPos.y, originalPos.z + controllerScript.rightAnalogY * boundaryCube.transform.localScale.z / 2);
        //transform.position = Vector3.MoveTowards(transform.position, newLoc, step);
        currentX = controllerScript.rightAnalogX;
        currentZ = controllerScript.rightAnalogY;
    }
}
