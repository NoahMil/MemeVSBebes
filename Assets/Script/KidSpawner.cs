using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
                if (kid.RandomSpawn)
                {
                    kid.Spawner = UnityEngine.Random.Range(0, transform.childCount);
                }
                GameObject kidInstance = Instantiate(kidsPrefabs[(int)kid.kidType], transform.GetChild(kid.Spawner).transform);
                transform.GetChild(kid.Spawner).GetComponent<SpawnPosition>().kids.Add(kidInstance);
                kid.isSpawned = true;
            }
        }
    }
    
    
}
