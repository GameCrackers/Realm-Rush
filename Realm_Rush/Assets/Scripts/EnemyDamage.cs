using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //[SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem EnemyDeathParticlePrefab;

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
        var vfx = Instantiate(EnemyDeathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitParticlePrefab.Play();
        hitPoints -= 1;
    }
}
