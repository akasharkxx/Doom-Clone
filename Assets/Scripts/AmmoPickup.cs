using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoInThisPickup = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.currentAmmo += ammoInThisPickup;
            PlayerController.instance.UpdateAmmoUI();
            Destroy(this.gameObject);
        }
    }
}
