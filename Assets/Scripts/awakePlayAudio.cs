using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class awakePlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void Awake()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
