using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public Canvas pauseMenuCanvas;

    public AudioMixerSnapshot normalVolume;
    public AudioMixerSnapshot pausedVolume;

    public bool isPaused = false;
    float originalVolume;

    public Button resumeButton;

    GameObject myEventSystem;

    GameObject golfBall;
    BallControl golfBallScript;

    GameObject controller;
    Controller controllerScript;

    GameObject levelManager;
    LevelManager levelManagerScript;

    // Use this for initialization
    void Start() {
        originalVolume = AudioListener.volume;
        pauseMenuCanvas.enabled = false;

        myEventSystem = GameObject.Find("EventSystem");

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();

        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<Controller>();

        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        levelManagerScript = levelManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("Start") && controllerScript.p1_isXbox) || (Input.GetButtonDown("StartP") && !controllerScript.p1_isXbox))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (!isPaused)
        {
            //AudioListener.volume = originalVolume / 10;
            pausedVolume.TransitionTo(0);
            isPaused = true;
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0;
            resumeButton.Select();
        }
        else if (isPaused)
        {
            Unpause();
        }
    }

    public void Unpause()
    {
        //AudioListener.volume = originalVolume;
        normalVolume.TransitionTo(.1f);
        isPaused = false;
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    public void returnToSelect()
    {
        Unpause();
        golfBallScript.ReturnToSelect();
        levelManagerScript.PlayMusic(levelManagerScript.Music_0);
    }
    public void returnToMainMenu()
    {
        Unpause();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
