using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI roundsText;

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void Contiunue()
    {
        Toggle();
    }
}
