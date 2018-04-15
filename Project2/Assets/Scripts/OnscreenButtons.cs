using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnscreenButtons : MonoBehaviour {
    public Transform myObject;
    Vector3 originalPos;
    Vector3 deltaPos;
    // Use this for initialization

    Vector3 origScale;
	void Start () {
        //deltaPos = myObject.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //deltaPos = myObject.position - originalPos;
        if (myObject)
        {
            transform.position = new Vector3(myObject.position.x + deltaPos.x, myObject.position.y + deltaPos.y, myObject.position.z + deltaPos.z);
        }
	}
}
