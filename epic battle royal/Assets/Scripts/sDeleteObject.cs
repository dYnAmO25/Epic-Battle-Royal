using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sDeleteObject : MonoBehaviour
{
    [SerializeField] float fTime;
    void Start()
    {
        Invoke("DeleteObject", fTime);
    }

    void DeleteObject()
    {
        Destroy(gameObject);
    }
}
