using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Kid
{
    public int spawnTime;
    public KidType kidType;
    public int Spawner;
    public bool RandomSpawner;
    public bool isSpawned;
}

public enum KidType
{
    Kid_blue,
    Kid_pink,
    Kid_green,
}
    