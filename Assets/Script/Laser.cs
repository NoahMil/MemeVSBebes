using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    void UpdateLaser()
    {
        
    }

    void DisableLaser()
    {
        
    }
}