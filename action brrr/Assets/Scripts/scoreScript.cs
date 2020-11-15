﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scoreScript : MonoBehaviour
{
    public int scoreValue;
    public int hiScore;

    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

}
