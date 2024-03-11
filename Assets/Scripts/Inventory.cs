using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    public List<PuzzleItens> items = new List<PuzzleItens>();
    private PuzzleItens itemSelecionado;
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
    public void ClearInventory()
    {
        items.Clear();
    }
    public void SelectItem(PuzzleItens item)
    {
        itemSelecionado = item;
    }

    public void UseSelectedItem(GameObject target)
    {
        if (itemSelecionado != null && itemSelecionado.puzzleItem)
        {
            itemSelecionado.UseItem(target);


            // Optionally, remove the used item from the inventory
            // RemoveItem(itemSelecionado);
        }
    }
}
