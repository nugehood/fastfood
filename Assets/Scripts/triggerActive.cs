using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerActive : MonoBehaviour
{
    public GameObject[] activatedObj;
    

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
            for(int i = 0;i <= activatedObj.Length; i++)
            {
                activatedObj[i].SetActive(true);
            }
        }
    }
}
