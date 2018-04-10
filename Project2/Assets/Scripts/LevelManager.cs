using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public GameObject beginPoint;

    public List<GameObject> levelStarts = new List<GameObject>();

    // Use this for initialization
    void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
