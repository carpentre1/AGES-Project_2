using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject controller;
    Controller controllerScript;

    Transform pivotPoint;

    public float lengthMultiplier = 4;
    public float minSize = 1;

    // Use this for initialization
    void Start () {
        pivotPoint = transform.parent.transform;

        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }
	
	// Update is called once per frame
	void Update () {
		pivotPoint.localScale = new Vector3(pivotPoint.localScale.x, Mathf.Max(minSize, controllerScript.LTInput * lengthMultiplier), pivotPoint.localScale.z);
    }
}
