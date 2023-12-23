using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStates.Rounds + " ROUND SURVIVED";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
