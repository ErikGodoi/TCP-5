using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleSolver : MonoBehaviour, IPointerClickHandler
{
    bool honey, babyBlock, branch, puzzleCompleto;
    public int etapa;
    public delegate void ItemClickAction(PuzzleItens clickedItem);

    public InventoryManager inventoryManager;

    public GameObject obstaculo;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.GetComponent<PuzzleSolver>());
        CheckList();
        if (honey && inventoryManager.selectedItem.name == "HoneyPot")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            return;
        }
        if (honey && inventoryManager.selectedItem.name == "BranchU")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            FimDoPuzzle();
            return;
        }
        if (honey && inventoryManager.selectedItem.name == "BabyBlock")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            FimDoPuzzle();
            return;
        }
        //else if (branch || babyBlock) inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
    }
    public void CheckList()
    {
        branch = false;
        babyBlock = false;
        if (inventoryManager.selectedItem.name == "HoneyPot") honey = true;
        if (inventoryManager.selectedItem.name == "BranchU") branch = true;
        if (inventoryManager.selectedItem.name == "BabyBlock") babyBlock = true;
    }
    public void FimDoPuzzle()
    {
        if (etapa == 3) obstaculo.SetActive(false);
    }
}