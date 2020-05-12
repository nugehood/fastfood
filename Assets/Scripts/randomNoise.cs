using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNoise : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] audioClips;
    public bool selectionPlay;

    public float timeLimit;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selectionPlay)
        {
            timer += Time.deltaTime;

            if (timer >= timeLimit)
            {
                audiosource.clip = audioClips[1];
                audiosource.Play();
                timer = 0;
            }
        }

        else if (selectionPlay)
        {
            audiosource.clip = audioClips[2];
        }
    }
}
