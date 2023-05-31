using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject goPlayer;
    [SerializeField] TMP_InputField input;

    [SerializeField] GameObject[] go;

    [SerializeField] bool bUseNames;
    [SerializeField] string[] sNames;
    
    int iPlayerAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(input.text, out iPlayerAmount);
    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < iPlayerAmount; i++)
        {
            Vector3 v3Spawn = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));

            GameObject goCurrentPlayer = Instantiate(goPlayer, v3Spawn, Quaternion.identity);
            
            if (bUseNames)
            {
                goCurrentPlayer.GetComponent<sUIManager>().sName = sNames[i % sNames.Length];
            }
            else
            {
                goCurrentPlayer.GetComponent<sUIManager>().sName = (i + 1).ToString();
            }
        }

        for (int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }
    }
}
