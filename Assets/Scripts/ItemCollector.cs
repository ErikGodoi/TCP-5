using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryUiController inventoryUi;

    public int cucaPzzl2Itens = 0;

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


        if (collision.gameObject.name.Contains("batWing") || collision.gameObject.name.Contains("vultureFeather") || collision.gameObject.name.Contains("ounceTooth") || 
            collision.gameObject.name.Contains("potionVial") || collision.gameObject.name.Contains("spiderLeg"))
        {
            cucaPzzl2Itens++;
            Debug.Log(cucaPzzl2Itens);
        }

    }
}
