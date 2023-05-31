using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text tName;
    [SerializeField] Image imageHP;
    [SerializeField] TMP_Text tKills;
    public string sName;
    [SerializeField] string sKillText;

     sAttack sAttack;

    void Start()
    {
        sAttack = GetComponent<sAttack>();
    }

    void Update()
    {
        tName.text = sName;

        imageHP.fillAmount = sAttack.iHP / 100;

        tKills.text = sKillText + sAttack.iKills.ToString();
    }
}
