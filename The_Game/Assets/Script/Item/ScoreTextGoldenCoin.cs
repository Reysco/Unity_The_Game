﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextGoldenCoin : MonoBehaviour
{

    Text text;
    public static int GoldencoinAmount;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GoldencoinAmount.ToString();
    }
}
