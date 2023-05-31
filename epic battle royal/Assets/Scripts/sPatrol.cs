using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPatrol : MonoBehaviour
{
    
    
    [SerializeField] int iChance;
    [SerializeField] int iWanderDistance;

    private Vector3 v3WanderDestination;
    public int iRandom;

    sMovement sMovement;
    sFindPlayer sFindPlayer;
    sGetOutOfZone sGetOutOfZone;

    void Start()
    {
        sMovement = GetComponent<sMovement>();
        sFindPlayer = GetComponent<sFindPlayer>();
        sGetOutOfZone = GetComponent<sGetOutOfZone>();
    }

    void FixedUpdate()
    {
        iRandom = Random.Range(0, iChance);
    }

    void Update()
    {
        if (iRandom == 0)
        {
            if (!sFindPlayer.bLocked)
            {
                if (!sGetOutOfZone.bInZone)
                {
                    v3WanderDestination = transform.position;

                    v3WanderDestination = GetRandomDestination(v3WanderDestination);

                    sMovement.v3Destination = v3WanderDestination;
                }
            }
        }
    }

    Vector3 GetRandomDestination(Vector3 v3Input)
    {
        v3Input.x += Random.Range(-iWanderDistance, iWanderDistance);
        v3Input.z += Random.Range(-iWanderDistance, iWanderDistance);

        return v3Input;
    }
}
