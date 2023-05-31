using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sZoneCloser : MonoBehaviour
{
    [SerializeField] GameObject[] goZoneX;
    [SerializeField] GameObject[] goZoneZ;
    [SerializeField] int iFactor;
    [SerializeField] int iExpanse;

    void Start()
    {
        
    }

    void Update()
    {
        if (goZoneZ[0].transform.localScale.z < iExpanse)
        {
            for (int i = 0; i < goZoneX.Length; i++)
            {
                Vector3 v3ChangeX = goZoneX[i].transform.localScale;

                v3ChangeX.x += (Time.deltaTime / 2 * iFactor);

                goZoneX[i].transform.localScale = v3ChangeX;
            }

            for (int i = 0; i < goZoneZ.Length; i++)
            {
                Vector3 v3ChangeZ = goZoneZ[i].transform.localScale;

                v3ChangeZ.z += (Time.deltaTime / 2 * iFactor);

                goZoneZ[i].transform.localScale = v3ChangeZ;
            }
        }
        else
        {
            for (int i = 0; i < goZoneX.Length; i++)
            {
                sZone sZoneX = goZoneX[i].GetComponent<sZone>();

                sZoneX.iDamageMultiplyer = 4;
            }

            for (int i = 0; i < goZoneZ.Length; i++)
            {
                sZone sZoneZ = goZoneZ[i].GetComponent<sZone>();

                sZoneZ.iDamageMultiplyer = 4;
            }
        }
    }
}
