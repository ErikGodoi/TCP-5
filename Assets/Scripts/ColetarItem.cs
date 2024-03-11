using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColetarItem : MonoBehaviour
{
    public Inventory inventario;

    public InventoryUiController inventoryUi;

    public bool p1BabyBlock;
    public bool p1BranchU;
    public bool p1Honey;
    private void Start()
    {
        inventario.ClearInventory();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PuzzleitemDisplay S_O_Holder = collision.gameObject.GetComponent<PuzzleitemDisplay>();
        if (collision.gameObject.name.Contains("babyBlock") && S_O_Holder != null)
        {
            p1BabyBlock = true;
            PuzzleItens referencia = S_O_Holder.puzzleItem;
            if (referencia != null)
            {
                referencia.Index = 0;
                inventario.AddItem(referencia);
                inventoryUi.UpdateUI();
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("Branch") && S_O_Holder != null)
        {
            p1BranchU = true;
            PuzzleItens referencia = S_O_Holder.puzzleItem;
            if (referencia != null)
            {
                referencia.Index = 1;
                inventario.AddItem(referencia);
                inventoryUi.UpdateUI();
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("Honey"))
        {
            p1Honey = true;
            PuzzleItens referencia = S_O_Holder.puzzleItem;
            if (referencia != null)
            {
                referencia.Index = 2;
                inventario.AddItem(referencia);
                inventoryUi.UpdateUI();
            }
            Destroy(collision.gameObject);
        }
    }
}
