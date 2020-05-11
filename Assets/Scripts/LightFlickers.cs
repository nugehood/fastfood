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
        flickers = (Random.value > 0.5f);
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

        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.1f;
    }

    IEnumerator normal()
    {
        light.intensity = 1f;

        yield return new WaitForSeconds(50f);
    }
}
