using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItemDisplay : MonoBehaviour, IPointerClickHandler
{
    public Image parentImage;
    public Sprite selecionado, naoSelecionado;
    public Image itemImage;
    public InventoryManager inventoryManager;
    public InventoryUiController inventoryUiController;

    public PuzzleItens item; // Reference to the associated item

    public bool itemSelecionado;

    public delegate void ItemClickAction (PuzzleItens clickedItem);
    //public static event ItemClickAction OnItemClick;

    private void Start()
    {
        inventoryUiController = FindObjectOfType<InventoryUiController>();
        parentImage.sprite = naoSelecionado;
        itemSelecionado = false;
        inventoryManager = FindObjectOfType<InventoryManager>();
        itemImage = GetComponent<Image>();
    }
    public void DisplayItem(PuzzleItens _item)
    {
        if (_item.sprite != null)
        {
            item = _item;
            itemImage.sprite = _item.sprite;
            itemImage.enabled = true;
        }
        else
        {
            itemImage.sprite = null;
            itemImage.enabled = false;
        }
    }
    // Clear the UI slot
    public void ClearItem()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
        parentImage.sprite = naoSelecionado;
    }
    // Handle item click
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item == null || !item.puzzleItem)
            return;

        if (!itemSelecionado)
        {
            SelecionarItem();
        }
        else
        {
            DeselecionarItem();
        }
    }
    private void SelecionarItem()
    {
        //DeselecionarItem();
        inventoryUiController.UpdateUI();
        parentImage.sprite = selecionado;
        itemSelecionado = true;
        inventoryManager.SelectItem(item);
        //Debug.Log("Item selected: " + item.itemName);
    }
    public void DeselecionarItem()
    {
        parentImage.sprite = naoSelecionado;
        itemSelecionado = false;
        inventoryManager.SelectItem(null);
        //Debug.Log("Item deselecionado: " + item.itemName);
    }
}
