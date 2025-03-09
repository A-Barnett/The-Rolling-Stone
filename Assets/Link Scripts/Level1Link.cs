using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Link : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
}