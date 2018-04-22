using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelSystem : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject levelManager;
    LevelManager levelManagerScript;

    int lastLevelVisited = 0;
    int[] Music0 = { 0 };
    int[] Music123 = { 1, 2, 3 };
    int[] Music456 = { 4, 5, 6 };
    int[] Music78 = { 7, 8 };
    int[] Music9 = { 9 };

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

                levelManagerScript.PlayMusic(levelManagerScript.Music_0);
                
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

                if(lastLevelVisited != golfBallScript.currentLevel)
                {
                    if(Music123.Contains(golfBallScript.currentLevel) && !Music123.Contains(lastLevelVisited))
                    {
                        levelManagerScript.PlayMusic(levelManagerScript.Music_123);
                    }
                    if (Music456.Contains(golfBallScript.currentLevel) && !Music456.Contains(lastLevelVisited))
                    {
                        levelManagerScript.PlayMusic(levelManagerScript.Music_456);
                    }
                    if (Music78.Contains(golfBallScript.currentLevel) && !Music78.Contains(lastLevelVisited))
                    {
                        levelManagerScript.PlayMusic(levelManagerScript.Music_78);
                    }
                    if (Music9.Contains(golfBallScript.currentLevel) && !Music9.Contains(lastLevelVisited))
                    {
                        levelManagerScript.PlayMusic(levelManagerScript.Music_9, 0);
                    }
                }

            }
        }
    }
    void FinalLevelToggle(bool starting)
    {
        if(starting)
        {

        }
        else
        {

        }
    }
}
