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
    public int _playerPosition = 1;

    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && _playerPosition > 0)
        {
            _playerPosition--;
            gameObject.transform.position = _playerLane[_playerPosition].position;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && _playerPosition < 3)
        {
            _playerPosition++;
            gameObject.transform.position = _playerLane[_playerPosition].position;
        }
    }
}
