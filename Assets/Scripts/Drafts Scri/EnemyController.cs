using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //for variables


    //for local component 
    private NavMeshAgent enemyNavMeshAgent;

    //for global and gambeobj
    public Transform playerTransform;
    public bool playerInDetectionRange = false;

    // Start is called before the first frame update
    void Awake()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // check if player in detection range to move enemy to player

        if(playerInDetectionRange==true)
        {
            enemyNavMeshAgent.transform.LookAt(playerTransform); // to make enemy look at player
            enemyNavMeshAgent.SetDestination(playerTransform.position + new Vector3(0, 0, 0.99f)); // move enemy to player
        }
    }
}