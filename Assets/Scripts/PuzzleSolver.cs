using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleSolver : MonoBehaviour, IPointerClickHandler
{
    // Cuca Puzzle 1 Variaveis
    bool honey, babyBlock, branch;
    bool puzzle1Completo;
    // Cuca Puzzle 2 Variaveis
    bool square, circle, triangle;
    bool puzzle2Completo;
    // Cuca Puzzle 3 Variaveis

    int etapa;
    public delegate void ItemClickAction(PuzzleItens clickedItem);

    public InventoryManager inventoryManager;

    [Header("Item a ser desativado ou ativado no fim do puzzle")]
    public GameObject obstaculo;

    bool cucaPuzzle1Completo;
    bool cucaPuzzle2Completo;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.GetComponent<PuzzleSolver>());
        if (!cucaPuzzle1Completo) CucaPuzzle1(eventData);
        if (cucaPuzzle1Completo && !cucaPuzzle2Completo) CucaPuzzle2(eventData);
        //else if (branch || babyBlock) inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
    }
    public void CucaPuzzle1(PointerEventData eventData)
    {
        if (etapa == 0 && inventoryManager.selectedItem.Index == 0)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            return;
        }
        if (etapa == 1 && inventoryManager.selectedItem.Index == 1)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            FimDoPuzzle();
            return;
        }
        if (etapa == 2 && inventoryManager.selectedItem.Index == 2)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            FimDoPuzzle();
            cucaPuzzle1Completo = true;
            return;
        }
    }
    public void CucaPuzzle2(PointerEventData eventData)
    {
        if (etapa <= 2 && inventoryManager.selectedItem.Index == 0 ||
            etapa <= 2 && inventoryManager.selectedItem.Index == 1 ||
            etapa <= 2 && inventoryManager.selectedItem.Index == 2)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            FimDoPuzzle();
            if (etapa == 3) cucaPuzzle2Completo = true;
            return;
        }
    }
    public void FimDoPuzzle()
    {
        if (!cucaPuzzle1Completo && etapa == 3)
        {
            obstaculo.SetActive(!obstaculo.activeSelf);
            etapa = 0;
        }
        if (cucaPuzzle1Completo && !cucaPuzzle2Completo && etapa == 3)
        {
            // Colocar o que mais precisa ser feito;
            obstaculo.SetActive(!obstaculo.activeSelf);
            etapa = 0;
        }
    }
}