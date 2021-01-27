using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    private void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
    }
}
