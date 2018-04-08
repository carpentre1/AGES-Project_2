using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    [Tooltip("Attach the starting point of the next level.")]
    public GameObject nextLevel;

    [Tooltip("If it's not the start point of the level, it's the finish point.")]
    public bool isLevelStart = true;

    public int level = 1;//change this value in the editor

	// Use this for initialization
	void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("z"))
        {
            Debug_SkipLevel();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!isLevelStart)//if they hit the finish point
        {
            if (other.tag == "Player")
            {
                golfBallScript.currentLevel++;
                if(!nextLevel)//if there are no more levels after this one
                {
                    golfBallScript.currentLevel = 1;//start them over at the beginning
                    golfBallScript.respawnPosition = new Vector3(2, 1, -3.75f);//the starting point for level 1
                    golfBallScript.ResetBall();
                    return;
                }
                golfBallScript.respawnPosition = nextLevel.transform.position;
                golfBallScript.ResetBall();
                
            }
        }
    }

    void Debug_SkipLevel()//level skipper for testing
    {
        if (level == golfBallScript.currentLevel && !isLevelStart)
        {
            Debug.Log(this.name + " " + level + " " + isLevelStart + " " + nextLevel);
            golfBallScript.currentLevel++;
            if (!nextLevel)
            {
                golfBallScript.currentLevel = 1;
                golfBallScript.respawnPosition = new Vector3(2, 1, -3.75f);
                golfBallScript.ResetBall();
                return;
            }
            golfBallScript.respawnPosition = nextLevel.transform.position;
            golfBallScript.ResetBall();
            return;
        }
    }
}
