﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawn = 1.5f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(secondsBetweenSpawn));
    }

    IEnumerator SpawnEnemy(float intervalSec)
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(intervalSec);
        }

     
    }


}
