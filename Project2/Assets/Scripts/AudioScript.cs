using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioSource golf1;
    public AudioSource golf2;
    public AudioSource golf3;
    public AudioSource heavyGolf1;
    public AudioSource heavyGolf2;
    public AudioSource ballInHole;

    public AudioSource whoosh;

    public AudioSource success;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
