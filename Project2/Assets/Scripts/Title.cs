using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    public Slider audioSlider;
    public GameObject creditsPanel;
    public GameObject audioPanel;
    public GameObject mainMenu;
    public Button start2;

    bool onAudioSlider = false;

    // Use this for initialization
    void Start () {
        start2.Select();
    }

    private void OnDestroy()
    {
        //PlayerPrefs.SetInt("Players", 1);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
            Debug.Log("this button quits when in a build rather than editor");
        }

        if (Input.GetButtonDown("Cancel"))//back button is 1 on xbox, 2 on ps4. fire is 0 on xbox, 1 on ps4
        {
            creditsPanel.SetActive(false);
            audioPanel.SetActive(false);
            mainMenu.SetActive(true);
            start2.Select();
            onAudioSlider = false;
        }
        if(onAudioSlider && Input.GetAxis("HorizontalUI") > .4f)
        {
            audioSlider.value += .01f;
        }
        if (onAudioSlider && Input.GetAxis("HorizontalUI") < -.4f)
        {
            audioSlider.value -= .01f;
        }
    }

    public void OnValueChanged()
    {
        AudioListener.volume = audioSlider.value;
    }
    public void SelectSlider()
    {
        onAudioSlider = true;
    }
}
