using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sZone : MonoBehaviour
{
    public int iDamageMultiplyer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<sGetOutOfZone>().bInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<sGetOutOfZone>().bInZone = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sAttack sAttack = other.gameObject.GetComponent<sAttack>();

            sAttack.iHP -= (Time.deltaTime / 2 * iDamageMultiplyer);
        }
    }
}
