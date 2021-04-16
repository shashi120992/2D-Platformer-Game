using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button Buttonplay;
    public GameObject levelSelection;
    private void Awake()
    {
        Buttonplay.onClick.AddListener(playGame);

    }

    private void playGame()
    {
        //SceneManager.LoadScene(1);
        levelSelection.SetActive(true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
