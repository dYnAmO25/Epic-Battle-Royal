using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text textPA;
    [SerializeField] TMP_Text textWS;
    [SerializeField] GameObject[] goPlayers;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goPlayers = GameObject.FindGameObjectsWithTag("Player");

        textPA.text = "Players Alive: " + goPlayers.Length.ToString();

        if (goPlayers.Length == 1)
        {
            textWS.text = goPlayers[0].GetComponent<sUIManager>().sName + " hat gewonnen!";
        }
    }
}
