using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 0.33f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
