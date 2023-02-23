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
    private bool _isArleadyFiringFreeze = false;
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
            _animator.SetTrigger("fire");
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("fire");
            FireFreeze();
        }
    }
    

    protected void FireFreeze()
    {
        if (!_isArleadyFiringFreeze)
        {
            StartCoroutine(FireFreezeWithDelay());
            _isArleadyFiringFreeze = true;

        }    
    }
    
    IEnumerator FireFreezeWithDelay()
    {
        Instantiate(freezebullet, pistolet.transform.position, pistolet.transform.rotation);
        firefreezeSE.Play();
        _animator.SetTrigger("canfire");
        yield return new WaitForSeconds(DelayFreezingValue);
        _isArleadyFiringFreeze = false;
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
        fireSE.Play();
        _animator.SetTrigger("canfire");
        yield return new WaitForSeconds(DelayValue);
        
        _isArleadyFiring = false;
    }
}
