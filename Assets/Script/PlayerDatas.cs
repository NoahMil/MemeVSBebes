using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject")] public class PlayerDatas : ScriptableObject
{
    [Header("STATS")]
    public float MaxLifePoint;
    public float LifePoint;
    public float movementSpeed;
    public float freezeWeakness;
}
