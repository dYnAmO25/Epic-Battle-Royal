using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetPlayerNumber : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text text;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = ((int)(slider.value * 100)).ToString();
    }
}
