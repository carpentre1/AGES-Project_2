using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public GameObject beginPoint;

    public List<GameObject> levelStarts = new List<GameObject>();
    public List<GameObject> levelSelectFlags = new List<GameObject>();

    // Use this for initialization
    void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateLevelCompletion(int level)
    {
        foreach(GameObject flag in levelSelectFlags)
        {
            if(flag.name.Contains(level.ToString()))
            {
                flag.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("changed color");
            }
        }
    }
}
