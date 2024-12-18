using UnityEngine;

public class Boomerang : MonoBehaviour
{
    private bool isReturning = false;
    private Transform target; // Spilleren som boomerangen returnerer til
    private Rigidbody2D rb;
    public float returnSpeed = 10f;
    public float maxTravelDistance = 5f; // Maksimal distanse før retur
    private Vector3 startPosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartReturnLogic(Transform playerTransform)
    {
        startPosition = transform.position;
        target = playerTransform;
        rb.isKinematic = false;
        isReturning = false;
    }

    void FixedUpdate()
    {
        if (!isReturning)
        {
            // Sjekk om boomerangen har reist lengre enn maks distanse
            float distanceTraveled = Vector3.Distance(startPosition, transform.position);
            if (distanceTraveled >= maxTravelDistance)
            {
                isReturning = true;
            }
        }
        else if (isReturning && target != null)
        {
            // Beregn retning mot spilleren
            Vector2 directionToPlayer = (target.position - transform.position).normalized;

            // Sett boomerangens hastighet mot spilleren
            rb.linearVelocity = directionToPlayer * returnSpeed;

            // Sjekk om boomerangen er nær spilleren
            if (Vector2.Distance(transform.position, target.position) < 0.5f)
            {
                Debug.Log("Boomerang returned to player!");
                rb.isKinematic = true;
                Destroy(gameObject); // Fjern boomerangen eller gjenbruk den
            }
        }
    }
}
