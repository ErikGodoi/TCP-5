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
    public bool cucaPuzzle2Completo;

    public int etapa;

    [Header("Cuca_Puzzle_1 Mudar Sprite da placa")]
    SpriteRenderer placa;
    public Sprite placa1;
    public Sprite placa2;
    public Sprite placa3;

    public CaldeiraoAnimacao caldAni;

    private void Start()
    {
        placa = gameObject.GetComponent<SpriteRenderer>();
        caldAni = GetComponent<CaldeiraoAnimacao>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.GetComponent<PuzzleSolver>());
        if (!cucaPuzzle1Completo && name == "c_c_Plate") CucaPuzzle1(eventData);
        if (!cucaPuzzle2Completo && name == "Caldeirao") CucaPuzzle2(eventData);
        //else if (branch || babyBlock) inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
    }
    public void CucaPuzzle1(PointerEventData eventData)
    {
        if (inventoryManager.selectedItem.itemName == null)
        {
            return;
        }
        if (etapa == 0 && inventoryManager.selectedItem.itemName == "honeyPot")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa = 1;
            placa.sprite = placa1;
        }
        else if (etapa == 1 && inventoryManager.selectedItem.itemName == "branchU")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa = 2;
            placa.sprite = placa2;
        }
        else if (etapa == 2 && inventoryManager.selectedItem.itemName == "babyBlock")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa = 3;
            placa.sprite = placa3;
            cucaPuzzle1Completo = true;
            FimDoPuzzle();
        }
    }
    public void CucaPuzzle2(PointerEventData eventData)
    {
        if (etapa <= 4 && inventoryManager.selectedItem.Index <= 4)
        {
            caldAni.Cooking();

            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            if (etapa == 5)
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
            recompensa.SetActive(!recompensa.activeSelf);
            etapa = 0;
        }
    }
}