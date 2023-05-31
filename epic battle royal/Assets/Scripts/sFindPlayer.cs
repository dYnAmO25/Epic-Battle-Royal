using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFindPlayer : MonoBehaviour
{
    public const int iRays = 5;

    public bool bLocked = false;
    
    Vector3[] av3Directions;
    RaycastHit[] hits;

    [SerializeField] GameObject goRayOrigin;
    [SerializeField] float fDistance;
    void Start()
    {
        av3Directions = new Vector3[iRays];

        hits = new RaycastHit[iRays];
    }

    void Update()
    {
        av3Directions[0] = transform.forward;
        av3Directions[1] = (transform.forward + -transform.right) / 2;
        av3Directions[1].Normalize();
        av3Directions[2] = (transform.forward + transform.right) / 2;
        av3Directions[2].Normalize();
        av3Directions[3] = (av3Directions[0] + av3Directions[1]) / 2;
        av3Directions[3].Normalize();
        av3Directions[4] = (av3Directions[0] + av3Directions[2]) / 2;
        av3Directions[4].Normalize();

        int iHit = -1;
        int iNonHits = 0;

        for (int i = 0; i < iRays; i++)
        {
            Debug.DrawRay(goRayOrigin.transform.position, av3Directions[i], Color.red);
            Physics.Raycast(goRayOrigin.transform.position, av3Directions[i], out hits[i], fDistance);

            if (hits[i].collider != null)
            {
                if (hits[i].collider.gameObject.tag == "Player")
                {
                    if (!GetComponent<sGetOutOfZone>().bInZone)
                    {
                        GetComponent<sMovement>().v3Destination = hits[i].collider.gameObject.transform.position;
                        iHit = i;
                    }
                }
                else
                {
                    iNonHits++;
                }
            }
            else
            {
                iNonHits++;
            }
        }

        if (iNonHits < iRays)
        {
            bLocked = true;
        }
        else
        {
            bLocked = false;
        }

    }
}