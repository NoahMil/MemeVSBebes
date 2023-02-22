using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KidController : MonoBehaviour
{
    [SerializeField] private float LifePoint;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float freezeWeakness;
    [SerializeField] private AudioSource deadKidSE;

    private bool frozen = false;
    private float mTimeScale = 1f;
    private float freezeTime = 5f;
    public delegate void UIEvent();
    public static event UIEvent OnUpdateScore;
    
    void Update()
    {

        if (frozen)
        {
            if (mTimeScale > 0f)
            {

                mTimeScale = 0f;
            }
            else
            {
                freezeTime -= Time.deltaTime;
                if (freezeTime <= 0f)
                {
                    UnFreeze();
                }
            }
        }
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime*mTimeScale, 0, 0));

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestructionZone"))
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 )
        {
            Freeze();
        }
    }

    public void ApplyDamage(int _damage)
    {
        LifePoint -= _damage;
        if (LifePoint <= 0)
        {
            Destroy(gameObject);
            deadKidSE.Play();
            OnUpdateScore?.Invoke();
        }

    }

    public void Freeze()
    {
        frozen = true;
        freezeTime = freezeWeakness;
    }

    public void UnFreeze()
    {
        frozen = false;
        mTimeScale = 1.0f;
        freezeTime = 0f;
    }
}
