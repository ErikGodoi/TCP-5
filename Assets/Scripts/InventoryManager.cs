using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<PuzzleItens> items = new List<PuzzleItens>();
    public PuzzleItens selectedItem {get; private set;}

    public void AddItem(PuzzleItens newItem)
    {
        if (newItem.stackable && items.Contains(newItem))
        {
            int index = items.IndexOf(newItem);
            items[index].quantidade++;
        }
        else
        {
            items.Add(newItem);
        }
    }
    public void RemoveItem(PuzzleItens itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }
    public void UseItem(PuzzleItens item, GameObject target)
    {
        if (item != null && item.puzzleItem)
        {
            item.UseItem(target);
            RemoveItem(item);
        }
    }
    public void SelectItem(PuzzleItens item)
    {
        selectedItem = item;
    }

    public void UseSelectedItem(GameObject target)
    {
        UseItem(selectedItem, target);
    }
}
