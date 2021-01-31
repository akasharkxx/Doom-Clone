using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float playerRange = 10f;
    public float moveSpeed = 5.0f;

    public int health = 3;
    public GameObject explosion;

    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector3.Distance(this.transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rBody.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            rBody.velocity = Vector3.zero;
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0) 
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
