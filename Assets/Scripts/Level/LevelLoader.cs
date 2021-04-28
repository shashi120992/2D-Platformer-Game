using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Sounds;

namespace Assets.Scripts.Level
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        public string LevelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            LevelStatus levelStatus = levelManager.Instance.GetLevelStatus(LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Cant play level till you unlok It");
                break;

                case LevelStatus.Unlocked:
                    Sounds.SoundManager.Instance.Play(Sounds.buttonClick);
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Complited:
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    SceneManager.LoadScene(LevelName);     // To Collect Extra Points
                    
                    break;
            }

             
        }
    }
}