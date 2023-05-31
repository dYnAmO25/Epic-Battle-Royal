using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sAttack : MonoBehaviour
{
    [SerializeField] Animation aAnimation;
    [SerializeField] GameObject goRayOrigin;
    [SerializeField] float fRange;
    [SerializeField] int iChance;
    [SerializeField] int iMaxDamage;
    [SerializeField] int iCooldown;
    [SerializeField] int iHPGain;
    [SerializeField] Material[] mats;
    [SerializeField] GameObject goKillEffect;
    [SerializeField] GameObject goHitEffect;

    public float iHP;
    public int iKills = 0;

    int iRandom;
    bool bDone;

    sFindPlayer sFindPlayer;
    MeshRenderer mrRenderer;
    void Start()
    {
        sFindPlayer = GetComponent<sFindPlayer>();
        mrRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        iRandom = Random.Range(0, iChance);
    }

    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(goRayOrigin.transform.position, transform.forward, out hit, fRange);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (iRandom < 10)
                {
                    if (!bDone)
                    {
                        AttackEnemy(hit);

                        bDone = true;

                        Invoke("ResetAttack", iCooldown);
                    }
                }
            }
        }
    }

    void AttackEnemy(RaycastHit hInput)
    {
        sAttack sEnemy = hInput.collider.gameObject.GetComponent<sAttack>();

        aAnimation.Play();
        Instantiate(goHitEffect, hInput.collider.gameObject.transform.position, Quaternion.identity);
        sEnemy.iHP -= Random.Range(1, iMaxDamage);
        sEnemy.Damaged();

        if (sEnemy.iHP <= 0)
        {
            Instantiate(goKillEffect, hInput.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(hInput.collider.gameObject);
            iKills++;
            iHP += iHPGain;

            if (iHP > 100)
            {
                iHP = 100;
            }
        }
    }

    void Damaged()
    {
        mrRenderer.material = mats[1];
        Invoke("ResetColor", 0.1f);
    }

    void ResetColor()
    {
        mrRenderer.material = mats[0];
    }

    void ResetAttack()
    {
        bDone = false;
    }
}
