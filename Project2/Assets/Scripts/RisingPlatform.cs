using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject controller;
    Controller controllerScript;

    Transform pivotPoint;

    List<GameObject> colliders = new List<GameObject>();

    float oldLTInput;
    float deltaLTInput;
    float deltaScale;

    public float level = 1;

    [Tooltip("How quickly the platform rises and falls. 0.1 to 0.5 are good values.")]
    public float speed = .5f;

    [Tooltip("How tall the platform should be when fully extended.")]
    public float lengthMultiplier = 4;
    [Tooltip("The minimum height of the platform when not extended at all.")]
    public float minSize = 1;

    Vector3 originalPos;

    // Use this for initialization
    void Start() {
        originalPos = transform.position;

        pivotPoint = transform.parent.transform;

        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }

    // Update is called once per frame
    void Update() {
        if(level != golfBallScript.currentLevel)
        {
            return;
        }
        //make the platform push out in increments
        deltaLTInput = controllerScript.LTInput - oldLTInput;
        //LTInput is 0 when left trigger is not touched, and goes up to 1 when pressed all the way down
        //pivotPoint.localScale = new Vector3(pivotPoint.localScale.x, Mathf.Max(minSize, controllerScript.LTInput * lengthMultiplier), pivotPoint.localScale.z);
        deltaScale = deltaLTInput * lengthMultiplier;
        if(pivotPoint.localScale.y < controllerScript.LTInput * lengthMultiplier)
        {
            pivotPoint.localScale = new Vector3(pivotPoint.localScale.x, pivotPoint.localScale.y + speed, pivotPoint.localScale.z);

        }
        if (pivotPoint.localScale.y > controllerScript.LTInput * lengthMultiplier)
        {
            pivotPoint.localScale = new Vector3(pivotPoint.localScale.x, Mathf.Max(minSize, pivotPoint.localScale.y - speed), pivotPoint.localScale.z);

        }

        if (colliders.Count != 0)
        {
            golfBall.GetComponent<Rigidbody>().AddForce(transform.up * 5 * deltaLTInput, ForceMode.Impulse);
        }
        
        oldLTInput = controllerScript.LTInput;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliders.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliders.Remove(collision.gameObject);
        }
    }
}
