﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventOnTimer : MonoBehaviour
{
    public float waitTime;
    float timer;
    public GameObject[] activeObj;
    public GameObject[] tagObj;
    public MouseLook look;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            for(int i=0;i < activeObj.Length; i++)
            {
                look.sitEvent = true;
                activeObj[i].SetActive(true);
                tagObj[i].tag = "music";
                Destroy(gameObject);
            }
        }
    }
}
