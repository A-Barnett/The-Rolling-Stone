using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelFlash : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI textBox;

    void OnEnable()
    {
        SceneManager.sceneLoaded += LoadScene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadScene;
    }

    IEnumerator ShowText()
    {
        CanvasGroup canvasGroup = textBox.GetComponent<CanvasGroup>();

        // Fade in
        float currentTime = 0f;
        float fadeDuration = 1f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            yield return null;
        }

        // Wait
        yield return new WaitForSeconds(2f);

        // Fade out
        currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, currentTime / fadeDuration);
            yield return null;
        }
        
    }

    void LoadScene(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.GetInt("Flag") == 0)
        {
            StartCoroutine(ShowText());
        }
    }
}
