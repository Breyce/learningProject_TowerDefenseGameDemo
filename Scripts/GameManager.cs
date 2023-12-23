using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool GameIsPause;

    public GameObject gameOverUI;
    public GameObject gamePauseUI;

    private void Start()
    {
        GameIsOver = false;
        GameIsPause = false;
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
        //Time.timeScale = 0;
        gameOverUI.gameObject.SetActive(true);
        //Debug.Log(gameOverUI.name);
    }

    private void PauseGame()
    {
        //GameIsPause = !GameIsPause;
        //gamePauseUI.gameObject.SetActive(GameIsPause);

        gamePauseUI.gameObject.SetActive(!gamePauseUI.activeSelf);

        if (gamePauseUI.gameObject.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        //Time.timeScale = GameIsPause ? 0 : 1;
    }
}
