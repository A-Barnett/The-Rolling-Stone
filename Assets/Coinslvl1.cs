using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Coinslvl1 : MonoBehaviour
{
    private int count;
    public TMPro.TextMeshProUGUI CountTxt;
    // Start is called before the first frame update
    void Start()
    {
       count = PlayerPrefs.GetInt("Level1");
       CountTxt.text = "Coins: " +
                       "" + count +"/40";

    }
}
