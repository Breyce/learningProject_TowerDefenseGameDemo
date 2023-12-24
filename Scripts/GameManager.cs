using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject gamePauseUI;
    public GameObject gameCompleteUI;


    public SceneFader fader;

    private void Start()
    {
        GameIsOver = false;
        WaveSpawner.EnemyAlive = 0;
    }

    void Update()
    {
        if (GameIsOver) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (PlayerStates.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.gameObject.SetActive(true);
        //Debug.Log(gameOverUI.name);
    }

    private void PauseGame()
    {

        gamePauseUI.gameObject.SetActive(!gamePauseUI.activeSelf);

        if (gamePauseUI.gameObject.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void WinLevel()
    {
        GameIsOver = true;
        gameCompleteUI.SetActive(true);
    }
}
