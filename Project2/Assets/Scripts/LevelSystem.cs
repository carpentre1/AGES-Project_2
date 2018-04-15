using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject levelManager;
    LevelManager levelManagerScript;

    public GameObject flag;

    [Tooltip("Attach the starting point of the next level.")]
    public GameObject nextLevel;


    public int level = 1;//change this value in the editor

	// Use this for initialization
	void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        levelManagerScript = levelManager.GetComponent<LevelManager>();

	}

    private void OnTriggerEnter(Collider other)
    {
        if(name.Contains("End"))//if they enter a level end hole, send them back to select
        {
            if (other.tag == "Player")
            {
                levelManagerScript.SFX_ballInHole.Play();
                golfBallScript.respawnPosition = levelManagerScript.beginPoint.transform.position;
                golfBallScript.ResetBall();

                levelManagerScript.UpdateLevelCompletion(golfBallScript.currentLevel);
                //levelManagerScript.SFX_fanfare1.Play();

                golfBallScript.currentLevel = 0;
                
            }
        }
        if (name.Contains("Select"))//if they enter a level select hole, send them to that level's start
        {
            if (other.tag == "Player")
            {
                foreach(GameObject newLevel in levelManagerScript.levelStarts)
                {
                    if (newLevel.name.Contains(level.ToString()))
                    {
                        nextLevel = newLevel;
                    }
                }
                levelManagerScript.SFX_whoosh.Play();
                golfBallScript.respawnPosition = nextLevel.transform.position;
                golfBallScript.ResetBall();
                golfBallScript.currentLevel = level;

            }
        }
    }
}
