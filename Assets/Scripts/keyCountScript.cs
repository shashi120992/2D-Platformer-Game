using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyCountScript : MonoBehaviour
{
    //Keycount Script
    public TextMeshProUGUI scoreText;
    private int keyCount = 0;
    public void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

    }

    public void increasekeyCount(int incriment)
    {
        keyCount += incriment;
        RefrreshUI();
    }

    public void Start()
    {
        RefrreshUI();
    }
    private void RefrreshUI()
    {
        scoreText.text = ": " + keyCount;
    }
}
