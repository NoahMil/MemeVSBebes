using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public KidSpawner kidSpawner;
    [SerializeField] private float LifePoint;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float freezeWeakness;
    [SerializeField] private AudioSource deadKidSE;
    [SerializeField] private float sounddelay;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private bool frozen = false;
    private float mTimeScale = 1f;
    private float freezeTime = 5f;
    private Animator _animator;
    public delegate void UIEvent();
    public static event UIEvent OnUpdateScore;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

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
            gameObject.transform.position = kidSpawner.spawnPoints[UnityEngine.Random.Range(0, kidSpawner.spawnPoints.Length)].position;
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
            deadKidSE.Play();
            StartCoroutine(deathKid());
        }

    } 
    IEnumerator deathKid()
    {
        _spriteRenderer.enabled = false; 
        _collider2D.enabled = false;
        OnUpdateScore?.Invoke();
        yield return new WaitForSeconds(sounddelay);
        Destroy(gameObject);
    }

    public void Freeze()
    {
        frozen = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        _animator.GetComponent<Animator>().enabled = false;
        freezeTime = freezeWeakness;
    }

    public void UnFreeze()
    {
        frozen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _animator.GetComponent<Animator>().enabled = true;
        gameObject.transform.rotation = Quaternion.identity;
        mTimeScale = 1.0f;
        freezeTime = 0f;
    }
    
    
}
