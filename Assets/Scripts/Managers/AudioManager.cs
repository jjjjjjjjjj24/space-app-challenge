using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Audios[] audioList;

    [System.Serializable]
    public class Audios
    {
        public string name;
        public AudioClip audio;
    }

    public void PlayAudio(string name)
    {
        for (int i = 0; i < audioList.Length; i++)
        {
            if (audioList[i].name.Equals(name))
            {
                audioSource.clip = audioList[i].audio;
                audioSource.Play();
            }
        }
    }

}
