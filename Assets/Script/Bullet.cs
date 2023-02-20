using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private  float speed;
    public int _damage;
    void Update()
    {
        transform.Translate(new Vector3(speed* Time.deltaTime, 0 ,0));
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
       other.gameObject.GetComponent<KidController>().ApplyDamage(_damage);
       Destroy(gameObject);
    }*/
}
