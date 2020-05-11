using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNoise : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] audioClips;

    public float timeLimit;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeLimit)
        {
            audiosource.clip = audioClips[1];
            audiosource.Play();
            timer = 0;
        }
    }
}
