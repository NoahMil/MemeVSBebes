using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Animator _animator;
    public GameObject bullet;
    public GameObject freezebullet;
    [SerializeField] private Transform[] _playerLane;
    [SerializeField] private PlayerDatas _playerData;
    [SerializeField] private GameObject pistolet;
    private int _playerPosition = 2;
    public int _damage;
    public float DelayValue = 2f;
    public float DelayFreezingValue = 2f;
    [SerializeField] private AudioSource fireSE;
    [SerializeField] private AudioSource firefreezeSE;
    private bool _isArleadyFiring = false;
    private void Start()
    {
        _playerData.LifePoint = _playerData.MaxLifePoint;
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _playerPosition > 0)
        {
            _playerPosition--;
            gameObject.transform.position = _playerLane[_playerPosition].position;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && _playerPosition < 4)
        {
            _playerPosition++;
            gameObject.transform.position = _playerLane[_playerPosition].position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            fireSE.Play();
            _animator.SetTrigger("fire");
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            FireFreeze();
            firefreezeSE.Play();
            _animator.SetTrigger("fire");

        }
    }
    

    protected void FireFreeze()
    {
        if (!_isArleadyFiring)
        {
            StartCoroutine(FireFreezeWithDelay());
            _isArleadyFiring = true;

        }    
    }
    
    IEnumerator FireFreezeWithDelay()
    {
        Instantiate(freezebullet, pistolet.transform.position, pistolet.transform.rotation);
        _animator.SetTrigger("canfire");
        yield return new WaitForSeconds(DelayFreezingValue);
        _isArleadyFiring = false;
    }

    protected void Fire()
    {
        if (!_isArleadyFiring)
        {
            StartCoroutine(FireWithDelay());
            _isArleadyFiring = true;

        }
    }
    IEnumerator FireWithDelay()
    {
        
        GameObject bulletInstance = Instantiate(bullet, pistolet.transform.position, pistolet.transform.rotation);
        bulletInstance.GetComponent<Bullet>()._damage = _damage;
        _animator.SetTrigger("canfire");
        yield return new WaitForSeconds(DelayValue);
        
        _isArleadyFiring = false;
    }
}
