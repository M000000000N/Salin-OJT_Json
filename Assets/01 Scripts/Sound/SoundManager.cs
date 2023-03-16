using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] sound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipNumber)
    {
        audioSource.clip = sound[clipNumber];
        audioSource.Play();
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
