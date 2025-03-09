using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pickups : MonoBehaviour
{
    private int counter;
    public TMPro.TextMeshProUGUI CountTxt;
    private int checkpointCounter;

    public SpriteRenderer star1;
    public SpriteRenderer star2;
    public SpriteRenderer star3;
    private bool St1;
    private bool St2;
    private bool St3;
    // Start is called before the first frame update


    void Start()
    {
        checkpointCounter = PlayerPrefs.GetInt("CheckpointCounter", 0);
        counter = checkpointCounter;
        CountTxt.text = "Coins: " + counter;
        if (PlayerPrefs.GetInt("star1") == 1)
        {
            Color color1 = star1.color;
            color1.a = 255f;
            star1.color = color1;
        }
        if (PlayerPrefs.GetInt("star2") == 1)
        {
            Color color2 = star2.color;
            color2.a = 255f;
            star2.color = color2;
        }
        if (PlayerPrefs.GetInt("star3") == 1)
        {
            Color color3 = star3.color;
            color3.a = 255f;
            star3.color = color3;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            counter++;
            CountTxt.text = "Coins: "+counter;

        }

        if (collider.gameObject.CompareTag("Star1"))
        {
            Color color1 = star1.color;
            color1.a = 255f;
            star1.color = color1;
            St1 = true;
        }
        if (collider.gameObject.CompareTag("Star2"))
        {
            Color color2 = star2.color;
            color2.a = 255f;
            star2.color = color2;
            St2 = true;
        }
        if (collider.gameObject.CompareTag("Star3"))
        {
            Color color3 = star3.color;
            color3.a = 255f;
            star3.color = color3;
            St3 = true;
        }
        if (collider.gameObject.CompareTag("Check"))
        {
            if (PlayerPrefs.GetInt("Flag") == 0)
            {
                checkpointCounter = counter;
                PlayerPrefs.SetInt("CheckpointCounter", checkpointCounter);
                PlayerPrefs.SetInt("Flag", 1);
                if (St1)
                {
                    PlayerPrefs.SetInt("star1",1);
                }
            }
        }
        if (collider.gameObject.CompareTag("Check2"))
        {
            if (PlayerPrefs.GetInt("Flag2") == 0)
            {
                checkpointCounter = counter;
                PlayerPrefs.SetInt("CheckpointCounter", checkpointCounter);
                PlayerPrefs.SetInt("Flag2", 1);
                if (St2)
                {
                    PlayerPrefs.SetInt("star2",1);
                }
            }
        }
        if(collider.gameObject.CompareTag("Finish"))
        { 
            if(counter > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name)){
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, counter);
            }
            PlayerPrefs.SetFloat("playerX",0);
            PlayerPrefs.SetFloat("playerY",0);
            PlayerPrefs.SetFloat("playerZ",0);
            PlayerPrefs.SetInt("Flag", 0);
            PlayerPrefs.SetInt("Flag2", 0);
            PlayerPrefs.SetInt("CheckpointCounter", 0);
            if (St1 || PlayerPrefs.GetInt("star1") ==1)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Star1",1);
            }
            if (St2|| PlayerPrefs.GetInt("star2") ==1)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Star2",1);
            }
            if (St3|| PlayerPrefs.GetInt("star3") ==1)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Star3",1);
            }
            PlayerPrefs.SetInt("star1", 0);
            PlayerPrefs.SetInt("star2", 0);
            PlayerPrefs.SetInt("star3", 0);
            SceneManager.LoadScene("Main Menu" , LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main Menu"));
        }
        
    }
    public void OnDeath()
    {
        counter = checkpointCounter;
      
    }

}
