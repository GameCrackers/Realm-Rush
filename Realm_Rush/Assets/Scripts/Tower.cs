using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] Transform enemyObject;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem bullets;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
       bool startFire = GameObject.Find("Enemy") != null;
        if (enemyObject)
        {
            FireAtEnemy(startFire);
        }
        else
        {
            ShootBullets(false);
        }


    }

    private void ShootBullets(bool startFirin)
    {
        var bulletEmissionModule = bullets.emission;
        bulletEmissionModule.enabled = startFirin;
    }

    private void FireAtEnemy(bool startFire)
    {
        float distanceToEnemy = Vector3.Distance(enemyObject.transform.position, gameObject.transform.position);
        if(distanceToEnemy <= attackRange)
        {
            towerTop.LookAt(enemyObject);
            bullets.Play();
            ShootBullets(true);
        }
        else
        {
            ShootBullets(false);
        }
    }
}
