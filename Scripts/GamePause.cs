using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;
    public TextMeshProUGUI roundsText;
    public string menuScene = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStates.Rounds + " ROUND SURVIVED";
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        //WaveSpawner.EnemyAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        Toggle();
        sceneFader.FadeTo(menuScene);
    }

    public void Contiunue()
    {
        Toggle();
    }
}
