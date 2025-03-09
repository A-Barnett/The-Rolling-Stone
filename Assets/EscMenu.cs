using UnityEngine;
using System.Collections;


public class EscMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isFadingIn && !isFadingOut)
            {
                if (canvasGroup.alpha > 0)
                {
                    StartCoroutine(FadeOut());
                }
                else
                {
                    StartCoroutine(FadeIn());
                }
            }
        }
    }

    IEnumerator FadeIn()
    {
        isFadingIn = true;

        float currentTime = 0f;
        canvasGroup.blocksRaycasts = true;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            yield return null;
        }

        isFadingIn = false;
    }

    IEnumerator FadeOut()
    {
        isFadingOut = true;

        float currentTime = 0f;
        canvasGroup.blocksRaycasts = false;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, currentTime / fadeDuration);
            yield return null;
        }

        isFadingOut = false;
    }
}