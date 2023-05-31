using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sMovement : MonoBehaviour
{
    public Vector3 v3Destination;
    
    private NavMeshAgent nmaAgent;
    void Start()
    {
        nmaAgent = GetComponent<NavMeshAgent>();
        v3Destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (nmaAgent.isActiveAndEnabled == true)
        {
            nmaAgent.SetDestination(v3Destination);
        }
    }
}
