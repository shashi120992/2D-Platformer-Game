using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class levelManager : MonoBehaviour
    {
        private static levelManager instance;
        //[SerializeField] private string level1;
        public string Level1;

        public static levelManager Instance { get { return instance; } }
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if(GetLevelStatus(Level1) == LevelStatus.Locked)
            {
                SetLevelStatus(Level1, LevelStatus.Unlocked);
            }
        }
        public LevelStatus GetLevelStatus(string level) 
        {
           LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int) levelStatus);
        }
    }
}