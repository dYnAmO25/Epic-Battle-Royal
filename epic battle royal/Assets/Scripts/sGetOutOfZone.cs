using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGetOutOfZone : MonoBehaviour
{
    public bool bInZone = false;

    sMovement sMovement;

    void Start()
    {
        sMovement = GetComponent<sMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bInZone)
        {
            sMovement.v3Destination = Vector3.zero;
        }
    }
}
