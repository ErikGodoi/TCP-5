using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItemDisplay : MonoBehaviour, IPointerClickHandler
{
    public Image itemImage;

    public PuzzleItens item1; // Reference to the associated item


    private Inventory playerInventory;

    public delegate void ItemClickAction (PuzzleItens clickedItem);
    public static event ItemClickAction OnItemClick;

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
        itemImage = GetComponent<Image>();
    }
    public void DisplayItem(PuzzleItens item)
    {
        if (item.sprite != null)
        {
            item1 = item;
            itemImage.sprite = item.sprite;
            itemImage.enabled = true;
            itemImage.color = new Color(255, 255, 255, 255);
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
        item1 = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
    // Handle item click
    public void OnPointerClick(PointerEventData eventData)
    {
        // Trigger the item click event
        if (item1 != null && OnItemClick != null)
        {
            playerInventory.SelectItem(item1);
            Debug.Log("Item selected: " + item1.itemName);
        }
    }
}
