using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIscript : MonoBehaviour
{
    public Slider visSlider;

    public NavMeshAgent agent;
    int randomPos;
    Vector3 randomDirection;
    public float x;
    public float walkRadius;
    public Transform playerPos;
    public bool playerinsight,searching,walking;
    public Movement PlayerMovement;
    public float timer;
    public float chaseWhen;

    public CameraFilterPack_TV_Distorted distorted;

    public Button eyes;

    public bool door;

    public visibilityScript visible;

    // Start is called before the first frame update
    void Start()
    {
        randomPos = Random.Range(0, 3);
        door = (Random.value > 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        visSlider.value = visible.limit;
        

        randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 3);
        Vector3 finalPosition = hit.position;

         x = Vector3.Distance(transform.position, playerPos.position);
       

       


        if (PlayerMovement.stealth)
        {
            chaseWhen = 5;
        }

        else if (!PlayerMovement.stealth)
        {
            chaseWhen = 10;
        }
        
        if(x <= chaseWhen)
        {
            eyes.interactable = true;

            agent.SetDestination(playerPos.position);
            playerinsight = true;
            searching = false;
            walking = true;
            
            distorted.RGB = 1f;
            distorted.Distortion = 3.9f;
        }

        
        

        else 
        {
            eyes.interactable = false;
            agent.SetDestination(finalPosition);
            
            playerinsight = false;
            searching = false;
            walking = true;
            distorted.RGB = 0.002f;
            distorted.Distortion = 1f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(randomDirection, walkRadius);
    }

    
}
