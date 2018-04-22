using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    GameObject golfBall;
    BallControl golfBallScript;

    public GameObject beginPoint;

    public AudioMixer masterMixer;

    public List<GameObject> levelStarts = new List<GameObject>();
    public List<GameObject> levelSelectFlags = new List<GameObject>();
    public GameObject confetti;
    public GameObject stars;
    public GameObject resultsText;
    public GameObject selectText;
    public GameObject tutorialText1;
    public GameObject tutorialText2;

    public AudioSource SFX_ballInHole;
    public AudioSource SFX_whoosh;
    public AudioSource SFX_fanfare1;

    public AudioSource Music_123;
    public AudioSource Music_456;
    public AudioSource Music_78;
    public AudioSource Music_9;
    public AudioSource Music_0;
    public AudioSource Music_Win;

    public AudioMixerSnapshot normalVolume;
    public AudioMixerSnapshot mutedVolume;

    public List<int> completedLevels = new List<int>();

    float difference = 0;

    // Use this for initialization
    void Start () {
        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        Music_0.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateLevelCompletion(int level)
    {
        if(!completedLevels.Contains(level))
        {
            completedLevels.Add(level);
            if(completedLevels.Count >= 9)
            {
                Debug.Log("yay");
                stars.SetActive(true);
                confetti.SetActive(true);
                Music_0 = Music_Win;
                PlayMusic(Music_0);
                selectText.GetComponent<Text>().text = "You win!";
                resultsText.GetComponent<Text>().text = "Deaths: " + golfBallScript.numDeaths + "\nPutts: " + golfBallScript.numPutts;
                resultsText.SetActive(true);
                tutorialText1.SetActive(false);
                tutorialText2.SetActive(false);
            }
        }
        foreach(GameObject flag in levelSelectFlags)
        {
            if(flag.name.Contains(level.ToString()))
            {
                flag.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
    public void PlayMusic(AudioSource music, float transitionDuration = .3f)
    {
        StartCoroutine(VolumeAdjust(transitionDuration, music));
    }
    IEnumerator VolumeAdjust(float transitionDuration, AudioSource music)
    {
        float deltaTime = 0;
        mutedVolume.TransitionTo(transitionDuration);
        while (deltaTime < transitionDuration)
        {
            deltaTime += .1f;
            yield return new WaitForSeconds(.1f);
        }
        Music_0.Pause();
        Music_123.Pause();
        Music_456.Pause();
        Music_78.Pause();
        Music_9.Pause();
        music.Play();
        deltaTime = 0;
        normalVolume.TransitionTo(transitionDuration);
    }
}
