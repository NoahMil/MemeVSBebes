using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public int Health;
    public int Damage;
    public float movementSpeed;
    private bool isStopped;
    private void Update()
    {
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isStopped = true;
        }
    }
}
