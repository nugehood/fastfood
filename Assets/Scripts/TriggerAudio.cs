using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip audioClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            Destroy(gameObject);
        }   
    }
}
