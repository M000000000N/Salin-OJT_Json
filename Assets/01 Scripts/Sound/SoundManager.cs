using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip sound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCrashSound()
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
