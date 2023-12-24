using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainScene";
    public string levelSelect = "LevelSelect";
    public SceneFader sceneFader;

    public void Play()
    {
        Debug.Log(levelToLoad);
        sceneFader.FadeTo(levelToLoad);
    }
    
    public void LevelSelect()
    {
        Debug.Log(levelSelect);
        sceneFader.FadeTo(levelSelect);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
