using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public Animator animator;
    public int parameter;
    public bool isopen;
    public AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("open",isopen);
        
    }

    public void closeDoor()
    {
        parameter = 2;
    }
    
}
