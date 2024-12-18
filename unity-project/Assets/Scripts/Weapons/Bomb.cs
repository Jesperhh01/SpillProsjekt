using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] 
    private int damage = 100;
    [SerializeField] public float explosionDelay = 3f;
    [SerializeField]
    private Explosion explosionPrefab; // Prefab med Explosion-skriptet

    private bool hasExploded = false;
    
    void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hasExploded)
        {
            Explode();
        }
    }
    
    public void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        // Instansier eksplosjons-prefaben på bombens posisjon
        if (explosionPrefab != null)
        {
            Explosion explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosion.TriggerExplosion();
        }

        // Ødelegg bomben
        Destroy(gameObject);
    }
}
