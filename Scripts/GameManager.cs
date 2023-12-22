using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded;

    void Update()
    {
        if (gameEnded) return;

        if (PlayerStates.Lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameEnded = true;
        Debug.Log("Game Over");
    }
}
