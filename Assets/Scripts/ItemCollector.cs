using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryUiController inventoryUi;

    private void Start()
    {
        inventoryManager.items.Clear();
        inventoryUi.UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PuzzleitemDisplay itemDisplay = collision.gameObject.GetComponent<PuzzleitemDisplay>();
        if (itemDisplay != null && itemDisplay.puzzleItem != null)
        {
            inventoryManager.AddItem(itemDisplay.puzzleItem);
            inventoryUi.UpdateUI();
            Destroy(collision.gameObject);
        }
    }
}
