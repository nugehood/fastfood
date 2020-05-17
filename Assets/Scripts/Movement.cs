using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 12f; 

    public CharacterController controller;

    public MouseLook look;

    AudioSource audioSource;

    public AudioClip walksfx;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.clip = walksfx;
            audioSource.Play();
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            audioSource.Stop();
        }
       
        
        if (Input.GetKeyDown(KeyCode.E)&&look.sitEvent)
        {
            controller.enabled = true;
            look.sitEvent = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
            audioSource.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.SimpleMove(move * speed);
    }
}
