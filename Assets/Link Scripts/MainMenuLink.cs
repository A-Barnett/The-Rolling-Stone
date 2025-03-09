using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLink : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetFloat("playerX",0);
        PlayerPrefs.SetFloat("playerY",0);
        PlayerPrefs.SetFloat("playerZ",0);
        PlayerPrefs.SetInt("Flag", 0);
        PlayerPrefs.SetInt("Flag2", 0);
        PlayerPrefs.SetInt("CheckpointCounter", 0);
        SceneManager.LoadScene("Main Menu");
    }
    
}
