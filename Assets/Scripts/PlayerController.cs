using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D playerBody;
    public Camera fpsCamera;
    public Animator gunAnimator;

    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;

    public int currentAmmo;
    public int maxHealth = 100;

    public GameObject bulletImpact;
    public GameObject deadScreen;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    private int currentHealth;

    private bool hasDead;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update Run every frame
    private void Update()
    {
        if(!hasDead)
        {
            MoveShootLook();
        }
    }

    private void MoveShootLook()
    {
        // Movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        playerBody.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // Mouse Look
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0f, 0f, mouseInput.x));

        fpsCamera.transform.localRotation = Quaternion.Euler(fpsCamera.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log($"I am Looking at {hit.transform.name}");
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    }
                }
                else
                {
                    Debug.Log("I am Looking at nothing");
                }
                currentAmmo--;
                gunAnimator.SetTrigger("Shoot");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            hasDead = true;
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
