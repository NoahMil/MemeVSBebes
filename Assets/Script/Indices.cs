using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Indices : MonoBehaviour
{
    public Score score;
    public KidSpawner _kidSpawner;
    private bool indicesPicked = false;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            score.stolenCandies++;
            indicesPicked = true;
            Destroy(gameObject);
            indicesPicked = false;
            score.Lose();
        }
    }


}

