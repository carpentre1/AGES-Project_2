using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnscreenButtons : MonoBehaviour {
    Transform theChild;
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
        {
            if (child.name.Contains("MovingPlatform"))
            {
                theChild = child;
            }
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(theChild)
        {
            transform.position = theChild.transform.position;
        }
	}
}
