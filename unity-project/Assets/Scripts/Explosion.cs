using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float explosionForce = 500f;
    [SerializeField]
    private float explosionRadius = 5f;
    [SerializeField]
    private float upwardsModifier = 0.5f;
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private LayerMask enemyLayer; // Lag som fiender befinner seg i
    [SerializeField]
    private GameObject explosionEffect; // Visuell effekt for eksplosjonen

    private void Awake()
    {
        // Sett enemyLayer programmatisk
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    
    public void TriggerExplosion()
    {
        Debug.Log($"Triggering explosion at {transform.position} with radius {explosionRadius}");

        // Finn alle kolliderende objekter innenfor radiusen
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        Debug.Log($"Found {hitColliders.Length} colliders in explosion radius.");

        
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log($"Hit: {hitCollider.gameObject.name}");

            Rigidbody2D rb = hitCollider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Debug.Log($"Applying force to {hitCollider.gameObject.name}");

                // Beregn retningen fra eksplosjonen til objektet
                Vector2 direction = rb.position - (Vector2)transform.position;
                float distance = direction.magnitude;

                // Påfør eksplosjonskraft basert på avstand
                float force = Mathf.Lerp(explosionForce, 0, distance / explosionRadius);
                rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            }

            // Påfør skade basert på avstand
            Health health = hitCollider.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log($"Applying damage to {hitCollider.gameObject.name}");

                float distance = Vector2.Distance(transform.position, hitCollider.transform.position);
                float damageToApply = Mathf.Max(0, damage * (1 - (distance / explosionRadius)));
                health.TakeDamage((int)damageToApply);
            }
        }

        // Spille av eksplosjonseffekt
        if (explosionEffect != null)
        {
            Debug.Log("Spawning explosion effect.");

            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        } 
        Destroy(gameObject, 2f);
    }

    private void OnDrawGizmosSelected()
    {
        // Tegn eksplosjonsradius i editoren for visualisering
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

