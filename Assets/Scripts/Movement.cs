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

    public bool notrun;

    bool walk;





    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //Lari
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.clip = walksfx;
            audioSource.Play();
            walk = true;
        }
        //Apabila tidak lari
        else if(Input.GetKeyUp(KeyCode.W) | notrun)
        {
            audioSource.Stop();
            walk = false;
        }
       
       
        //Apabila duduk
        if (Input.GetKeyDown(KeyCode.E)&&look.sitEvent)
        {
            controller.enabled = true;
            look.sitEvent = false;
            notrun = false;
        }

        //Apabila jalan
        if (Input.GetKey(KeyCode.LeftShift))
        {
            audioSource.Stop();
            speed = 5f;
           
        }
        //Apabila tidak jalan
        else if (Input.GetKeyUp(KeyCode.LeftShift)&&walk)
        {
            audioSource.Play(); 
            speed = 10f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.SimpleMove(move * speed);
    }

    

}
