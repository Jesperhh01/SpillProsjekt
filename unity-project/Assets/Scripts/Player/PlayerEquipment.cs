using System;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Transform weaponHolder;
    public GameObject currentWeapon;
    public float throwForce = 0.1f;
    private BoxCollider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        currentWeapon = Instantiate(weaponPrefab, weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
    }

    public void ThrowWeapon(Vector2 direction)
    {
        
        if (currentWeapon != null)
        {
            currentWeapon.transform.parent = null;
            
            Rigidbody2D rb = currentWeapon.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = currentWeapon.AddComponent<Rigidbody2D>();
            }
            
            // Aktiver fysikk
            rb.isKinematic = false;
            rb.gravityScale = 0f;
            rb.linearDamping = 1f;
            rb.angularDamping = 1f;

            // Påfør kraft for å kaste våpenet
            rb.AddForce(direction * throwForce);
            
            // Ignorer kollisjon mellom spilleren og bomben
            Collider2D bombCollider = currentWeapon.GetComponent<Collider2D>();
            if (bombCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, bombCollider);
            }
            
            Boomerang boomerang = currentWeapon.GetComponent<Boomerang>();
            if (boomerang != null)
            {
                boomerang.StartReturnLogic(playerCollider.transform); // Start retur-logikk for boomerangen
            }
            
            currentWeapon = null;
        }
        
    }
}
