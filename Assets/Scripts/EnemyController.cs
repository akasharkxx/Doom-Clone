using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float playerRange = 10f;
    public float moveSpeed = 5.0f;

    public int health = 3;
    public GameObject explosion;
    public GameObject bulletPrefab;

    public bool shouldShoot;
    public float fireRate = .5f;

    public Transform firePoint;

    private float shotCounter;

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
            
            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    GameObject enemyBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                    Destroy(enemyBullet, 4f);
                }
            }
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
