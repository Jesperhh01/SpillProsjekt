using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 
 public List<InventoryItem> inventoryItems = new List<InventoryItem>();
 public InventoryUI inventoryUI; // Referanse til InventoryUI
 public PlayerEquipment playerEquipment;
 
 //Prefabs for våpen. Bør finne en ryddigere måte å gjøre dette på.
    public GameObject bombPrefab;
    public GameObject boomerangPrefab;

 //Legg til et objekt i inventory
 public void AddItem(string name, int quantity, string description)
 {
     //Sjekk om objektet allerede finnes i inventory
    InventoryItem existingItem = inventoryItems.Find(item => item.itemName == name);
    if (existingItem != null)
    {
        existingItem.itemQuantity += quantity; //Øk antall
    }
    else //legg til nytt objekt
    {
        inventoryItems.Add(new InventoryItem { itemName = name, itemQuantity = quantity, itemDescription = description });
    }
    // Kall UpdateInventoryUI i InventoryUI
    if (inventoryUI != null)
    {
        inventoryUI.UpdateInventoryUI(inventoryItems);
    }
 }
 
    //Fjern et objekt fra inventory
    public void RemoveItem(string name, int quantity)
    {
        InventoryItem existingItem = inventoryItems.Find(item => item.itemName == name);
        if (existingItem != null)
        {
            existingItem.itemQuantity -= quantity; //Reduser antall
            if (existingItem.itemQuantity <= 0)
            {
                inventoryItems.Remove(existingItem); //Fjern objektet fra inventory hvis antall er 0
            }
        }
    }
    
    //Ustyr med et item
    public void EquipItem(string name)
    {
        Debug.Log($"Ustyrt med {name}");
        GameObject weaponPrefab = GetWeaponPrefab(name);
        if (weaponPrefab != null && playerEquipment != null)
        {
            playerEquipment.EquipWeapon(weaponPrefab);
        }
        else
        {
            Debug.LogWarning("Fant ikke weapon prefab eller playerEquipment mangler.");
        }
    }

    public GameObject GetWeaponPrefab(string itemName)
    {
        if (itemName == "Bomb") return bombPrefab;
        if (itemName == "Boomerang") return boomerangPrefab;

        return null;
    }
    
    
    
}
