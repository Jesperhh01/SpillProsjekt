using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject platformPrefab;
    public Vector3[] platformPositions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Vector3 position in platformPositions)
        {
            Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }

}
