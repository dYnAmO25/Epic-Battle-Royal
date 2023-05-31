using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sExplosion : MonoBehaviour
{
    [SerializeField] float fRadius;
    [SerializeField] float fForce;
    [SerializeField] float fTime;
    
    Collider[] other;
    void Start()
    {
        other = Physics.OverlapSphere(transform.position, fRadius);

        for (int i = 0; i < other.Length; i++)
        {
            if (other[i].gameObject.tag == "Player")
            {
                other[i].gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
                other[i].gameObject.GetComponent<NavMeshAgent>().updateRotation = false;
                other[i].gameObject.GetComponent<NavMeshAgent>().enabled = false;

                other[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(fForce, transform.position, fRadius);
            }
        }

        Invoke("EnableNavAgent", fTime);
    }

    void EnableNavAgent()
    {
        for (int i = 0; i < other.Length; i++)
        {
            if (other[i] != null)
            {
                if(other[i].gameObject.tag == "Player")
                {
                    other[i].gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    other[i].gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
                    other[i].gameObject.GetComponent<NavMeshAgent>().updateRotation = true;
                }
            }
        }
    }
}
