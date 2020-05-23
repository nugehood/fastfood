using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    public NavMeshAgent agent;
    int randomPos;
    Vector3 randomDirection;
    public float x;
    public float walkRadius;
    public Transform playerPos;
    public bool playerinsight,searching,walking;

    public CameraFilterPack_TV_Distorted distorted;
    

    // Start is called before the first frame update
    void Start()
    {
        randomPos = Random.Range(0, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 3);
        Vector3 finalPosition = hit.position;

         x = Vector3.Distance(transform.position, playerPos.position);

        
        
        if(x <= 10)
        {
            agent.SetDestination(playerPos.position);
            playerinsight = true;
            searching = false;
            walking = true;

            distorted.RGB = 1f;
            distorted.Distortion = 3.9f;
        }
        else
        {
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
