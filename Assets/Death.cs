using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lowerY;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetFloat("playerX") ==0)
        {
            playerPosition = rb.transform.position;
            PlayerPrefs.SetFloat("playerX", playerPosition.x);
            PlayerPrefs.SetFloat("playerY", playerPosition.y);
            PlayerPrefs.SetFloat("playerZ", playerPosition.z);
        }
        float x = PlayerPrefs.GetFloat("playerX");
        float y = PlayerPrefs.GetFloat("playerY");
        float z = PlayerPrefs.GetFloat("playerZ");
        transform.position = new Vector3(x, y, z);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        { 
            onDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Check"))
        {
            playerPosition = rb.transform.position;
            PlayerPrefs.SetFloat("playerX", playerPosition.x);
            PlayerPrefs.SetFloat("playerY", playerPosition.y);
            PlayerPrefs.SetFloat("playerZ", playerPosition.z);
        }
        if(collision.CompareTag("Check2"))
        {
            playerPosition = rb.transform.position;
            PlayerPrefs.SetFloat("playerX", playerPosition.x);
            PlayerPrefs.SetFloat("playerY", playerPosition.y);
            PlayerPrefs.SetFloat("playerZ", playerPosition.z);
        }

        if (collision.CompareTag("Lava"))
        {
            onDeath();
        }
    }

    public void onDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rb.position;
        if (pos.y < lowerY)
        {
            onDeath();
        }

    }
}
