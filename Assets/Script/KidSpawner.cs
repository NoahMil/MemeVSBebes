using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using Random = System.Random;

public class KidSpawner : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;
    [SerializeField] private Transform[] spawnpoints;
    private float timeBetweenSpawns;
    private int i = 0;
    private bool stopSpawning = false;
    public int killedkid;
    
    private void Awake()
    {
        currentWave = waves[i];
        timeBetweenSpawns = currentWave.TimeBeforeThisWave;
    }
    

    private void Update()
    {
        if (stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBetweenSpawns && killedkid >= currentWave.NumberToKill) ;
        {
            SpawnWave();
            IncWave();

            timeBetweenSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }

        if (killedkid <= currentWave.NumberToKill)
        {
            SpawnWave();
        }

    }


    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = UnityEngine.Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = UnityEngine.Random.Range(0, spawnpoints.Length);
            
          Instantiate(currentWave.EnemiesInWave[num], spawnpoints[num2].position, spawnpoints[num2].rotation);
          
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }

        else
        {
            stopSpawning = true;
        }
    }

}
