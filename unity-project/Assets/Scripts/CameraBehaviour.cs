using UnityEngine;

public class CameraBeahaviour : MonoBehaviour
{
    public Transform target; // Referanse til spilleren eller objektet kameraet skal følge
    public float smoothSpeed = 0.125f; // Hvor glatt kameraet skal bevege seg
    public Vector3 offset; // Forskyvning fra spilleren

    void LateUpdate()
    {
        // Beregn ønsket posisjon
        Vector3 desiredPosition = target.position + offset;

        // Myk overgang til ønsket posisjon
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Oppdater kameraets posisjon
        transform.position = smoothedPosition;
    }
}

