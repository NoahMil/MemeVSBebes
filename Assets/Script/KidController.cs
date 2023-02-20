using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KidController : MonoBehaviour
{
    [SerializeField] private  int _health;
    [SerializeField] private  int _damage;
    [SerializeField] private  float movementSpeed;
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

    public void ApplyDamage(int _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            transform.parent.GetComponent<SpawnPosition>().kids.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
