using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Canvas pauseMenuCanvas;

    public bool isPaused = false;
    float originalVolume;

    public Button resumeButton;

    GameObject myEventSystem;

    GameObject golfBall;
    BallControl golfBallScript;

    // Use this for initialization
    void Start() {
        originalVolume = AudioListener.volume;
        pauseMenuCanvas.enabled = false;

        myEventSystem = GameObject.Find("EventSystem");

        golfBall = GameObject.FindGameObjectWithTag("Player");
        golfBallScript = golfBall.GetComponent<BallControl>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (!isPaused)
        {
            AudioListener.volume = originalVolume / 10;
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
        AudioListener.volume = originalVolume;
        isPaused = false;
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    public void returnToSelect()
    {
        Unpause();
        golfBallScript.ReturnToSelect();
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
