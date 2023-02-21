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
    
 
    
    public float scanRadius = 3f;
    public LayerMask filterMask;
    private KidSpawner KS; 
    private Collider2D checkCollider;
    
    public delegate void UIEvent();
    public static event UIEvent OnUpdateScore;
    
    void Awake()
    {
        KS = FindObjectOfType<KidSpawner>();
    }

    void Update()
    {
        checkCollider = Physics2D.OverlapCircle(transform.position, scanRadius, filterMask);
        if (checkCollider != null && checkCollider.transform != transform)
        {
            Destroy(checkCollider.gameObject);
        }
        
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));

    }
    
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isStopped = true;
        }
    }

    public void ApplyDamage(int _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
            OnUpdateScore?.Invoke();
        }
    }
}
