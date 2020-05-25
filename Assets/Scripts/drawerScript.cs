using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerScript : MonoBehaviour
{
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            StartCoroutine(openDrawer());
            timer = 0;
        }

    }

    IEnumerator openDrawer()
    {
        
        yield return new WaitForSeconds(2);
        transform.Translate(Vector3.back);
    }
}
