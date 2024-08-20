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
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryUi = FindObjectOfType<InventoryUiController>();
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
        if (collision.gameObject.name.Contains("Poison")) cucaPzzl2Itens = 5;

        if (collision.gameObject.name.Contains("Puzzle 2"))
        {
            cucaPzzl2Itens++;
            Debug.Log(cucaPzzl2Itens);
        }
        if (collision.gameObject.name.Contains("Check") && cucaPzzl2Itens == 5)
        {
            collision.gameObject.SetActive(false);
            cucaPzzl2Itens = 0;
        }
    }
}
