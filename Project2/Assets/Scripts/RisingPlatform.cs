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
        //LTInput is 0 when left trigger is not touched, and goes up to 1 when pressed all the way down
        pivotPoint.localScale = new Vector3(pivotPoint.localScale.x, Mathf.Max(minSize, controllerScript.LTInput * lengthMultiplier), pivotPoint.localScale.z);
        if(colliders.Count != 0)
        {
            golfBall.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
        }
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
