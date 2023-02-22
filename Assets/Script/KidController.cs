using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public Player player;
    [SerializeField] private  int _health;
    [SerializeField] private  int _damage;
    [SerializeField] private  float movementSpeed;
    public float DelayValue = 2f;
    private bool _isArleadyAttacking = false;
    
    public delegate void UIEvent();
    public static event UIEvent OnUpdateScore;
    
    void Update()
    {
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
    }
    
    public  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestructionZone"))
        {
            Destroy(gameObject);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Trigger!");
            Attack();
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
    
    protected void Attack()
    {
        if (!_isArleadyAttacking)
        {
            StartCoroutine(AttackwithDelay());
            _isArleadyAttacking = true;

        }
    }
    IEnumerator AttackwithDelay()
    {
        yield return new WaitForSeconds(DelayValue);
        player.ApplyDamage(_damage);
        _isArleadyAttacking = false;
    }
}
