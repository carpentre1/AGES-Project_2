using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public void Load(int players)
    {
        if(players == 1) { PlayerPrefs.SetInt("Players", 1); }
        else if(players == 2) { PlayerPrefs.SetInt("Players", 2); }
        SceneManager.LoadScene(1);
    }
}