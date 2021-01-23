using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform fpsCamera;

    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    // Update Run every frame
    private void Update()
    {
        // Movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        playerBody.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // Mouse Look
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0f, 0f, mouseInput.x));

        fpsCamera.localRotation = Quaternion.Euler(fpsCamera.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        // Shooting
    }

}
