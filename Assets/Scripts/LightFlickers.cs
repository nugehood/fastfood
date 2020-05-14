using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickers : MonoBehaviour
{
    public bool flickers;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flickers)
        {
            StartCoroutine(flicker());
          
        }

        else if (!flickers)
        {
            StartCoroutine(normal());
            
        }
    }

    IEnumerator flicker()
    {
        light.intensity = 1f;
        yield return new WaitForSeconds(0.3f);
        light.intensity = 0.1f;
    }

    IEnumerator normal()
    {
        light.intensity = 1f;

        yield return new WaitForSeconds(50f);
    }
}
