using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareFx : MonoBehaviour
{
    public CameraFilterPack_TV_Distorted fx;
    public AudioSource audioSource;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        for(int i = 0;i <= 9; i++)
        {
            fx.Distortion = i;
            fx.RGB = i;
            StartCoroutine(stopit());
        }
    }

    public IEnumerator stopit()
    {
        yield return new WaitForSeconds(1);
        fx.Distortion = 1;
        fx.RGB = 0.002f;
        Destroy(gameObject);    
        StopCoroutine(stopit());
    }
}
