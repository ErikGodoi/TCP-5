using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryUiController inventoryUi;
    public Backpack backPack;
    public float velo;

    public int cucaPzzl2Itens = 0;
    Collider2D objetoDeColisao;
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryUi = FindObjectOfType<InventoryUiController>();
        inventoryManager.items.Clear();
        inventoryUi.UpdateUI();
    }
    private void FixedUpdate()
    {
        ProInventario();
    }
    void ProInventario()
    {
        if (objetoDeColisao != null)
        {
            objetoDeColisao.gameObject.transform.position = Vector2.MoveTowards(objetoDeColisao.gameObject.transform.position, backPack.transform.position, velo * Time.fixedDeltaTime);
            Debug.Log(Vector3.Distance(objetoDeColisao.gameObject.transform.position, backPack.transform.position));
            if (Vector3.Distance(objetoDeColisao.gameObject.transform.position, backPack.transform.position) <= 90f)
            {
                Destroy(objetoDeColisao.gameObject);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PuzzleitemDisplay itemDisplay = collision.gameObject.GetComponent<PuzzleitemDisplay>();
        if (itemDisplay != null && itemDisplay.puzzleItem != null)
        {
            inventoryManager.AddItem(itemDisplay.puzzleItem);
            inventoryUi.UpdateUI();
            objetoDeColisao = collision;
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
