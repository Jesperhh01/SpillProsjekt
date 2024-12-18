using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Queue<GameObject> slotPool = new Queue<GameObject>(); // Pool for gjenbruk av slots
    public InventoryManager _inventoryManager;

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            slotPool.Enqueue(child.gameObject);
        }
    }

    public void UpdateInventoryUI(List<InventoryItem> inventoryItems)
    {
       foreach (Transform child in transform)
       {
           child.gameObject.SetActive(false);
           slotPool.Enqueue(child.gameObject);
       }
       
       foreach (InventoryItem item in inventoryItems)
       {
           GameObject slot;
           if (slotPool.Count > 0)
           {
               slot = slotPool.Dequeue();
               slot.SetActive(true);
           }
           else
           {
               Debug.LogError("Ikke nok slots i hierarkiet! Vurder å legge til flere.");
               continue;
           }
           // Oppdater slot UI
           InventorySlotUI slotUI = slot.GetComponent<InventorySlotUI>();
           if (slotUI != null)
           {
               slotUI.InitializeSlot(item.itemName, _inventoryManager);
           }

       }
    }
}
