using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuScene = "MainMenu";
    public SceneFader sceneFader;

    public void Restart()
    {
        //WaveSpawner.EnemyAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        sceneFader.FadeTo(menuScene);
    }
}
