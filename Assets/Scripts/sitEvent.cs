using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sitEvent : MonoBehaviour
{
    public MouseLook camera;

    public GameObject[] activatedObj;
    public bool destroy;
    public GameObject[] destroyObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.isSit&&!destroy)
        {
            for(int i = 0;i < activatedObj.Length; i++)
            {
                activatedObj[i].SetActive(true);
            } 

        }

        else if (camera.isSit && destroy)
        {
            for(int i = 0;i < activatedObj.Length; i++)
            {
                activatedObj[i].SetActive(true);
            }

            for (int i = 0; i < destroyObj.Length; i++)
            {
                Destroy(destroyObj[i]);
            }
        }
    }
}
