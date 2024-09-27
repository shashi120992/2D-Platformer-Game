using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scorecontroller : MonoBehaviour
{
    //Score controller
    public TextMeshProUGUI scoreText;
    private int Score = 100;
    public void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

    }

    public void increaseScore(int incriment)
    {
        Score += incriment;
        RefreshUI();
    }

    public void Start()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "Score : " + Score;
    }
}
