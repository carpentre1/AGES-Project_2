using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public GameObject beginPoint;

    public List<GameObject> levelStarts = new List<GameObject>();
    public List<GameObject> levelSelectFlags = new List<GameObject>();

    public AudioSource SFX_ballInHole;
    public AudioSource SFX_whoosh;
    public AudioSource SFX_fanfare1;

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
            }
        }
    }
}
