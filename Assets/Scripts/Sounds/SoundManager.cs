using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager instance;
        public static SoundManager Instance { get { return instance; } }

        public SoundType[] Sounds;

        public AudioSource soundEffects;
        public AudioSource soundMusic;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        internal void Play(object buttonclick)
        {
            throw new NotImplementedException();
        }

        public void Play(Sounds sound)
        {
            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                soundEffects.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Clip not found for sound type: " + sound);
            }
        }

        private AudioClip getSoundClip(Sounds sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if (i != null)
                return item.soundClip;
            return null;
        }
    }
    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    public enum Sounds
    {
        ButtonClick,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
    }
}
    

