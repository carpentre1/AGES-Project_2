using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float speed = 1;
    public float maxSpeed = 2;
    float yPos;
    bool movingForwards = true;

    CharacterController cc;
    Rigidbody rb;

    GameObject controller;
    Controller controllerScript;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        //cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        yPos = transform.position.y;
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerScript.B_Down())
        {
            MoveForward();
        }
        else
        {
            MoveBackward();
        }
    }

    void MoveForward()
    {
        var localVel = transform.InverseTransformDirection(rb.velocity);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        //rb.velocity = transform.forward * speed;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
    void MoveBackward()
    {
        var localVel = transform.InverseTransformDirection(rb.velocity);
        rb.AddForce(-transform.forward * speed, ForceMode.Impulse);
        //rb.velocity = -transform.forward * speed;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
