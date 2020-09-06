using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //[SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

    private void OnParticleCollision(GameObject gameObject)
    {
        print("I'm hit!");

        ProcessHit();

        if(hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
    }
}
