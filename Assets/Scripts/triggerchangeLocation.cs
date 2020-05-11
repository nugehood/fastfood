using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerchangeLocation : MonoBehaviour
{
    public Transform obj;
    public Transform spawnLocation;


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
        if (other.gameObject.CompareTag("Player"))
        {
            obj.position = spawnLocation.position;
            

        }
    }
}
