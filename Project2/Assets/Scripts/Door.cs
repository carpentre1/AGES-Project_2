using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    GameObject controller;
    Controller controllerScript;

    GameObject golfBall;
    BallControl golfBallScript;

    bool doorOpening = false;
    bool doorClosing = false;
    bool doorOpen = false;

    float openingSpeed = .05f;
    float stayOpenDuration = 2;
    float totalDistance = 10;
    float doorOpenMagnitude = 1;

    // Use this for initialization
    void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controllerScript.Y_Down())
        {
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        if(doorOpening || doorClosing || doorOpen)
        {
            return;
        }
        foreach(Transform child in transform)
        {
            MoveDoor(child.gameObject);
        }
    }
    void MoveDoor(GameObject child)
    {
        if(child.name == "Left")
        {
            StartCoroutine(OpeningCoroutine(true, child));
        }
        else if (child.name == "Right")
        {
            StartCoroutine(OpeningCoroutine(false, child));
        }
    }
    IEnumerator OpeningCoroutine(bool toLeft, GameObject child)
    {
        doorOpening = true;
        float openedDistance = 0;
        while(openedDistance < totalDistance)
        {
            if(toLeft) { child.transform.Translate(Vector3.left * .07f * doorOpenMagnitude); }
            else if(!toLeft) { child.transform.Translate(Vector3.right * .07f * doorOpenMagnitude); }
            yield return new WaitForSeconds(openingSpeed);
            openedDistance += 1;
        }
        doorOpen = true;
        doorOpening = false;
        float timeOpen = 0;
        while(timeOpen < stayOpenDuration)
        {
            yield return new WaitForSeconds(.1f);
            timeOpen += .1f;
        }
        StartCoroutine(ClosingCoroutine(toLeft, child));

    }
    IEnumerator ClosingCoroutine(bool toLeft, GameObject child)
    {
        float openedDistance = 0;
        while (openedDistance < totalDistance)
        {
            if (toLeft) { child.transform.Translate(Vector3.right * .07f * doorOpenMagnitude); }
            else if (!toLeft) { child.transform.Translate(Vector3.left * .07f * doorOpenMagnitude); }
            yield return new WaitForSeconds(openingSpeed);
            openedDistance += 1;
        }
        doorOpen = false;
    }

}
