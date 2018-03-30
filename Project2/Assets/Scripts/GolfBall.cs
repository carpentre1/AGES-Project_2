using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

    Rigidbody rb;
    public GameObject ballDirection;

    public float xAxis;
    public float zAxis;
    Vector3 originalPos;

    public float extraThrust = 200;//the amount of extra power for tuning how far the ball can go

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        originalPos = ballDirection.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        originalPos = transform.position;//keep the ball direction indicator in the same spot as the ball itself
	}

    public void RotateBall(float vInput, float hInput)
    {
        ballDirection.transform.position = new Vector3(originalPos.x - vInput, originalPos.y, originalPos.z - hInput);//move the 'ball direction indicator' in the direction of the analog; this works perfectly

    }
    public void Putt(float thrust)
    {
        rb.velocity = new Vector3(0, 0, 0);//reset the ball's velocity before we putt it again
        transform.LookAt(ballDirection.transform);//make the ball stare in the direction of the 'ball direction indicator'. this also works as intended
        thrust *= extraThrust;//thrust is 0 to 1, extraThrust is a public variable used for tuning how far the ball should go
        rb.AddForce(transform.forward * thrust);//send the ball in its forwards direction. has weird issue where it can't send in the upper right and right directions? all other directions work as intended
    }
}
