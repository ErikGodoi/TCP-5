using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleSolver : MonoBehaviour, IPointerClickHandler
{
    public delegate void ItemClickAction(PuzzleItens clickedItem);

    public InventoryManager inventoryManager;


    [Header("Item a ser desativado ou ativado no fim do puzzle")]
    public GameObject recompensa;

    bool cucaPuzzle1Completo;
    bool cucaPuzzle2Completo;

    int etapa;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.GetComponent<PuzzleSolver>());
        if (!cucaPuzzle1Completo && name == "c_c_Plate") CucaPuzzle1(eventData);
        if (!cucaPuzzle2Completo && name == "Caldeirao") CucaPuzzle2(eventData);
        //else if (branch || babyBlock) inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
    }
    public void CucaPuzzle1(PointerEventData eventData)
    {
        if (etapa <= 2 && inventoryManager.selectedItem.Index <= 2)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            if (etapa == 3)
            {
                cucaPuzzle1Completo = true;
                FimDoPuzzle();
            }
        }
    }
    public void CucaPuzzle2(PointerEventData eventData)
    {
        if (etapa <= 3 && inventoryManager.selectedItem.Index <= 3)
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            if (etapa == 4)
            {
                cucaPuzzle2Completo = true;
                FimDoPuzzle();
            }
        }
    }
    public void FimDoPuzzle()
    {
        if (cucaPuzzle1Completo)
        {
            recompensa.SetActive(!recompensa.activeSelf);
            etapa = 0;
        }
        if (cucaPuzzle2Completo)
        {
            // Colocar o que mais precisa ser feito quando o puzzle for completo;

            //Ativar Linha abaixo se algum obstaculo/recompensa precisa ser Ativado/Desativado quando o Puzzle 2 (Caldeirao) for completo.
            //recompensa.SetActive(!recompensa.activeSelf);
            etapa = 0;
        }
    }
}