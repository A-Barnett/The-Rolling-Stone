using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCheck2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level2" + gameObject.name) == 1)
        {
            Color color = sprite.color;
            color.a = 255f;
            sprite.color = color;
        }
        
    }
}
