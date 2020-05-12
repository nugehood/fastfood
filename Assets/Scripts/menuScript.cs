using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class menuScript : MonoBehaviour
{
    public GameObject Director;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Director.SetActive(true);
    }
}
