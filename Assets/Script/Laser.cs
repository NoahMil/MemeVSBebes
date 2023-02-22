using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public class LaserScript : MonoBehaviour
    {
        [Header("Laser pieces")] public GameObject laserStart;
        public GameObject laserMiddle;
        public GameObject laserEnd;

        private GameObject start;
        private GameObject middle;
        private GameObject end;
    }
}
    

