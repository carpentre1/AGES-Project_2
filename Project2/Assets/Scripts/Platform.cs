﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float speed = 1;
    public float backSpeedMult = .5f;
    public float maxSpeed = 2;
    float yPos;
    float originalX;
    float deltaX = 0;
    bool movingForwards = true;

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject SFX;
    AudioScript SFXScript;

    CharacterController cc;
    Rigidbody rb;

    GameObject controller;
    Controller controllerScript;

    public int level = 1;

    // Use this for initialization
    void Start()
    {
        originalX = transform.position.x;

        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        SFX = GameObject.FindGameObjectWithTag("SFX");
        SFXScript = SFX.GetComponent<AudioScript>();

        rb = GetComponent<Rigidbody>();
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (level != golfBallScript.currentLevel)
        {
            return;//don't do anything if the player isn't on this level
        }
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
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
    void MoveBackward()
    {
        var localVel = transform.InverseTransformDirection(rb.velocity);
        rb.AddForce(-transform.forward * speed * backSpeedMult, ForceMode.Impulse);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
