using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public string description;
    public InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("kolliderte med spiller");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spilleren kolliderte med et pickup-item!");
            if (inventoryManager != null)
            {
                inventoryManager.AddItem(itemName, quantity, description);
            }
            else
            {
                Debug.LogError("Fant ikke InventoryManager i scenen!");
            }
            Destroy(gameObject);
        }
    }
}
