using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;
    public float speed = 5f;

    private Rigidbody2D rBody;
    private Vector3 direction;


    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * speed;
    }

    private void FixedUpdate()
    {
        rBody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            PlayerController.instance.TakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
    }
}
