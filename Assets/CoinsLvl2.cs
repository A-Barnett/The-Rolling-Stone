using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLvl2 : MonoBehaviour
{
    private int count;
    public TMPro.TextMeshProUGUI CountTxt;
        // Start is called before the first frame update
        void Start()
        {
            count = PlayerPrefs.GetInt("Level2");
            CountTxt.text = "Coins: " +
                            "" + count +"/55";

        }
    }

