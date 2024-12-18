using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlotUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    private string itemName;
    public Button selectButton; // Referanse til knappen
    private InventoryManager _inventoryManager;
    
    public void InitializeSlot(string newItemName, InventoryManager manager)
    {
        itemName = newItemName;
        itemNameText.text = itemName;
        _inventoryManager = manager;
        selectButton.onClick.AddListener(OnSlotClicked);

    }
    
    public void OnSlotClicked()
    {
        Debug.Log("Slot clicked!");
        if (!string.IsNullOrEmpty(itemName))
        {
            Debug.Log($"Valgte {itemName} fra inventory.");
            _inventoryManager.EquipItem(itemName); // Utstyrer våpen
        }
    }
}