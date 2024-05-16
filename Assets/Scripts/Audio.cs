using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //tao bien luu tru audio source

    public AudioSource musicAudioSource;

    //tao bien luu tru audio clip
    public AudioClip musicClip;
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();

    }
  
}
