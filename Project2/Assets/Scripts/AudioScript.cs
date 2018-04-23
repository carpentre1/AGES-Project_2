using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    //handles audio for the various moving platforms
    //not in use - couldn't get audio to sound good on the various platform movement mechanics

    public AudioSource golf1;
    public AudioSource golf2;
    public AudioSource golf3;
    public AudioSource heavyGolf1;
    public AudioSource heavyGolf2;
    public AudioSource ballInHole;

    public AudioSource redPlatform;
    public AudioSource purplePlatform;
    public AudioSource grayPlatform;
    public AudioSource door;

    public AudioSource whoosh;

    public AudioSource success;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayContinuousAudio(AudioSource audio)
    {
        if(!audio.isPlaying)
        {
            audio.Play();
        }
        else
        {
            audio.UnPause();
        }
    }
    public void PauseContinuousAudio(AudioSource audio)
    {
        audio.Pause();
    }
}
