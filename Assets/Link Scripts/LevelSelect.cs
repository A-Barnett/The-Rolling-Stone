using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level Select");
    }
    
}

