using System.Collections;
using TMPro;
using UnityEngine;

public class RoundSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStates.Rounds)
        {
            round++;
            roundsText.text = round +" ROUND SURVIVED";

            yield return new WaitForSeconds(.05f);
        }
    }

}
