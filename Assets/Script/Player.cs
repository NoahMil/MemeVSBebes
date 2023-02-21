using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform[] _playerLane;
    private int _playerPosition = 2;
    
    public GameObject bullet;
    [SerializeField] private  int _health;
    [SerializeField] private  int _damage;
    [SerializeField] private float DelayValue = 2f;
    private bool _isArleadyFiring = false;

    

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
        }
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
        GameObject bulletInstance = Instantiate(bullet, _playerLane[_playerPosition].transform.position, _playerLane[_playerPosition].transform.rotation);
        bulletInstance.GetComponent<Bullet>()._damage = _damage;
        yield return new WaitForSeconds(DelayValue);
        
        _isArleadyFiring = false;
    }
}
