using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyB : MonoBehaviour
{
    public void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1 && PlayerPrefs.GetInt("Flag") ==1)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("Flag") == 0)
            {
                PlayerPrefs.SetInt(gameObject.name, 1);
            }
        }
    }
}
    