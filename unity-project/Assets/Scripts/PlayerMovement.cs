using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 movement;
    private bool isKnockedBack = false;
    private Animator animator;
    private Vector2 lastDirection;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            HandleMovement();
            UpdateAnimator();
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
    
    private void UpdateAnimator()
    {
        float tolerance = 0.1f; // Mindre toleranse for å sikre at små bevegelser ikke blir ignorert

        // Sjekk om spilleren faktisk beveger seg
        bool isMoving = movement.magnitude > tolerance;

        // Oppdater Animator-parametere
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            // Oppdater siste gyldige bevegelsesretning
            lastDirection = movement;

            // Bruk den faktiske bevegelsesretningen
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        else
        {
            // Bruk siste gyldige retning når det ikke er momentum
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }
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
    
    


