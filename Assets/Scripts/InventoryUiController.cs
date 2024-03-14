using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiController : MonoBehaviour
{
    public List<UIItemDisplay> itemDisplays;
    public InventoryManager inventoryManager;

    // Update the UI to display the player's inventory
    public void UpdateUI()
    {
        for (int i = 0; i < itemDisplays.Count; i++)
        {
            if (i < inventoryManager.items.Count)
            {
                // If the slot index is within the range of the items in the inventory, display the item
                itemDisplays[i].DisplayItem(inventoryManager.items[i]);
            }
            else
            {
                // If the slot index is beyond the number of items, clear the slot
                itemDisplays[i].ClearItem();
            }
        }
    }
}
