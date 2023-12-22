using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    private void Update()
    {
        livesText.text = "Lives LEFT:\n" + PlayerStates.Lives;
    }

}
