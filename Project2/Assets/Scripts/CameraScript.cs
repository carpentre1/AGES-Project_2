using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float xOffset;
    public float yOffset;
    public float zOffset;

    public Transform golfBall;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(golfBall.position.x + xOffset, golfBall.position.y + yOffset, golfBall.position.z + zOffset);
    }
}
