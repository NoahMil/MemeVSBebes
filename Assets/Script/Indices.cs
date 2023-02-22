using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indices : MonoBehaviour
{
    public Score score;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            score.stolenCandies++;
            Destroy(gameObject);
            score.Lose();
        }
    }
}

