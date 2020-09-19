using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem bullets;

    Waypoint baseWaypoint;

    // Start is called before the first frame update
    // Update is called once per frame
    
    
    Transform enemyObject;
    

    public Waypoint GetBaseWaypoint()
    {
        return baseWaypoint;
    }

    public void SetBaseWaypoint(Waypoint waypoint)
    {
        baseWaypoint = waypoint;
    }


    void Update()
    {
        SetTargetEnemy();

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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyMovement>();

        if(sceneEnemies.Length == 0) { return; }

        Transform closestTransform = sceneEnemies[0].transform;
        foreach (EnemyMovement sceneEnemy in sceneEnemies)
        {
            if (Vector3.Distance(closestTransform.position, gameObject.transform.position) >= 
                Vector3.Distance(sceneEnemy.transform.position, gameObject.transform.position))
            {
                closestTransform = sceneEnemy.transform;
            }

        }

        enemyObject = closestTransform;
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
