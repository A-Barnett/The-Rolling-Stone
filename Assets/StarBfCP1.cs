using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBfCP1 : MonoBehaviour
{
    public SpriteRenderer sprite;
    public void Start()
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1 && PlayerPrefs.GetInt("Flag") ==1)
            {
                Color color = sprite.color;
                color.a = 0.43f;
                sprite.color = color;
            }
        }

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Color color = sprite.color;
                color.a = 0.43f;
                sprite.color = color;
                if (PlayerPrefs.GetInt("Flag") == 0)
                {
                    PlayerPrefs.SetInt(gameObject.name, 1);
                }
            }
        }
    }