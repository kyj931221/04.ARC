using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor.SearchService;

public class EffectManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    public float waitTime = 1.0f;

    private void Start()
    {
        StartCoroutine(FadeInOutLoadScene(1));
    }

    IEnumerator FadeInOutLoadScene(int sceneId)
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(waitTime);
        yield return StartCoroutine(FadeOutAndLoadScene(sceneId));
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }

    IEnumerator FadeOutAndLoadScene(int sceneId)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1.0f - (elapsedTime / fadeDuration));
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0f);

        SceneManager.LoadScene(sceneId);
    }
}
