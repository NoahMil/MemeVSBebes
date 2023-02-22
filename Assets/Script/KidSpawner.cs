using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int NbEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class KidSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
    public Text waveName;
    
    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    private bool canSpawn = true;
    private bool canAnimate = false;

    private void Start()
    {
        animator.SetTrigger("WaveComplete");
    }

    private void Update()
    { 
        currentWave= waves[currentWaveNumber];
        SpawnWave();
         GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Kid");
        if (totalEnemies.Length == 0)
        {
            if (currentWaveNumber+1 != waves.Length && canAnimate)
            {
                if (canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            }
        }
    }

    void SpawnWave()
    {
      if (canSpawn && nextSpawnTime < Time.time)
      {
          GameObject randomEnemy =
              currentWave.typeOfEnemies[UnityEngine.Random.Range(0, currentWave.typeOfEnemies.Length)];
          Transform randomPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
          Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
          currentWave.NbEnemies--;
          nextSpawnTime = Time.time + currentWave.spawnInterval;

          if (currentWave.NbEnemies == 0)
          {
              canSpawn = false;
              canAnimate = true;
          }
      }
    }
    void SpawnNextWave()
    {
        currentWaveNumber++; 
        canSpawn = true; 
    }
  
}

