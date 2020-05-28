using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDestroyOnSeconds : MonoBehaviour
{
    public GameObject[] destroyedObject;

    public float DestroyOn;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(destroyObj(DestroyOn));
        }
    }


    public IEnumerator destroyObj(float delay)
    {
        yield return new WaitForSeconds(delay);
        for(int i = 0;i <= destroyedObject.Length; i++)
        {
            Destroy(destroyedObject[i]);
        }
    }
}
