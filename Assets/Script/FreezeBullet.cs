using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [HideInInspector] public int frozentime;


    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<KidController>().Freeze();
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestructionZone"))
        {
            Destroy(gameObject);
        }
    }
}
