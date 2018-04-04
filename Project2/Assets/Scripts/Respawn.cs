using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public int level = 1;//change this value in the editor

	// Use this for initialization
	void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
        Debug.Log(golfBall.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player");
            if (golfBallScript.currentLevel < level)
            {
                golfBallScript.currentLevel = level;
                golfBallScript.respawnPosition = transform.position;
                Debug.Log("new respawn");
            }
        }
    }
}
