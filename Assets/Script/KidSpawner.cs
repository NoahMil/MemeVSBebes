using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidSpawner : MonoBehaviour
{
    public List<GameObject> kidsPrefabs;
    public List<Kid> kids;

    private void Update()
    {
        foreach (Kid kid in kids)
        {
            if (kid.isSpawned == false && kid.spawnTime <= Time.time)
            {
                Instantiate(kidsPrefabs[(int)kid.kidType], transform.GetChild(kid.Spawner).transform);
                kid.isSpawned = true;
            }
            
        }
    }
}
