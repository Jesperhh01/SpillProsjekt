using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHealth = 100; // Fiendens helse
    private int currentHealth; // Fiendens nåværende helse
    public float speed = 2f;
    [SerializeField]
    public float followRadius;
    public int damage = 20; // Skaden fienden gjør per treff
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Finn spilleren via tag
        currentHealth = maxHealth; // Sett nåværende helse til maks helse
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            
            if (distanceToPlayer <= followRadius)
            {
                // Beveg fienden mot spilleren
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)direction * (speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected!");

            Vector2 knockback = (collision.transform.position - transform.position).normalized;
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            Health health = collision.gameObject.GetComponent<Health>();


            if (playerMovement != null)
            {
                Debug.Log("Applying knockback to player...");
                playerMovement.ApplyKnockback(knockback * 10f); // Bruker ApplyKnockback-metoden
                health.TakeDamage(damage); // Bruker TakeDamage-metoden
            }
            else
            {
                Debug.Log("PlayerMovement script missing on Player!");
            }
        }

    }
}