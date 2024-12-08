using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 movement;
    private bool isKnockedBack = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            HandleMovement();
    }

    public void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = movement * speed;
        }    
    }

    void HandleMovement()
    {
        // Get input in Update
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal, vertical).normalized;
    }

    public void ApplyKnockback(Vector2 knockbackForce)
    {
        isKnockedBack = true;
        rb.AddForce(knockbackForce, ForceMode2D.Impulse);
        Invoke(nameof(EndKnockback), 0.2f); // Slutt knockback etter 0.2 sekunder
    }

    void EndKnockback()
    {
        isKnockedBack = false;
    }
    
    
    
}
    
    


