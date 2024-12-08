using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 10; // Skaden fienden gjør per treff
    public int health = 100; 
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Finn spilleren via tag
    }

    void Update()
    {
        if (player != null)
        {
            // Beveg fienden mot spilleren
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * (speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected!");

            Vector2 knockback = (collision.transform.position - transform.position).normalized;
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                Debug.Log("Applying knockback to player...");
                playerMovement.ApplyKnockback(knockback * 500f); // Bruker ApplyKnockback-metoden
            }
            else
            {
                Debug.Log("PlayerMovement script missing on Player!");
            }
        }
    }
}