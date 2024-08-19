using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PuzzleSolver : MonoBehaviour, IPointerClickHandler
{
    public delegate void ItemClickAction(PuzzleItens clickedItem);

    public InventoryManager inventoryManager;

    [Header("Item a ser desativado ou ativado no fim do puzzle")]
    public GameObject[] recompensa;

    bool cucaPuzzle1Completo;
    public bool cucaPuzzle2Completo;
    bool cucaBossFight;

    public int etapa;

    [Header("Cuca_Puzzle_1 Mudar Sprite da placa")]
    SpriteRenderer placa;
    public Sprite placa1;
    public Sprite placa2;
    public Sprite placa3;

    public CaldeiraoAnimacao caldAni;

    [Header("Cuca boss fight")]
    Cuca_Logic cuca;
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        cuca = GetComponent<Cuca_Logic>();
        placa = gameObject.GetComponent<SpriteRenderer>();
        caldAni = GetComponent<CaldeiraoAnimacao>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.GetComponent<PuzzleSolver>());
        if (!cucaPuzzle1Completo && name == "c_c_Plate") CucaPuzzle1(eventData);
        if (!cucaPuzzle2Completo && name == "Caldeirao") CucaPuzzle2(eventData);
        if (!cucaBossFight && name == "Cuca(Clone)") CucaBoss(eventData);
        //else if (branch || babyBlock) inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
    }
    public void CucaPuzzle1(PointerEventData eventData)
    {
        try
        {
            if (inventoryManager.selectedItem == null || inventoryManager.selectedItem.itemName == null)
            {
                return;
            }
        }
        catch (Exception e) { Debug.Log(e.Message); }
        if (!cucaPuzzle1Completo && etapa == 0 && inventoryManager.selectedItem.itemName == "honeyPot")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa = 1;
            placa.sprite = placa1;
        }
        else if (!cucaPuzzle1Completo && etapa == 1 && inventoryManager.selectedItem.itemName == "branchU")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa = 2;
            placa.sprite = placa2;
        }
        else if (!cucaPuzzle1Completo && etapa == 2 && inventoryManager.selectedItem.itemName == "babyBlock")
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
        try
        {
            if (inventoryManager.selectedItem == null || inventoryManager.selectedItem.itemName == null)
            {
                return;
            }
        }
        catch (Exception e) { Debug.Log(e.Message); }
        if (!cucaPuzzle2Completo && etapa <= 4 && inventoryManager.selectedItem.Index <= 4)
        {
            caldAni.animar = true;
            caldAni.Cooking();

            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            etapa++;
            if (etapa == 5)
            {
                cucaPuzzle2Completo = true;
                caldAni.animar = false;
                caldAni.Cooking();
                FimDoPuzzle();
            }
        }
    }
    public void CucaBoss(PointerEventData eventData)
    {
        try
        {
            if (inventoryManager.selectedItem == null || inventoryManager.selectedItem.itemName == null)
            {
                return;
            }
        }
        catch (Exception e) { Debug.Log(e.Message); }
        if (!cucaBossFight && inventoryManager.selectedItem.itemName == "poisonVial")
        {
            inventoryManager.UseSelectedItem(eventData.pointerClick.GetComponent<PuzzleSolver>());
            cucaBossFight = true;
            FimDoPuzzle();
        }
    }
    public void FimDoPuzzle()
    {
        if (cucaPuzzle1Completo)
        {
            for (int i = 0; i < recompensa.Length; i++)
            {
                recompensa[i].SetActive(!recompensa[i].activeSelf);
            }
            etapa = 0;
            inventoryManager.CloseBackPack();
        }
        if (cucaPuzzle2Completo)
        {
            for (int i = 0; i < recompensa.Length; i++)
            {
                recompensa[i].SetActive(!recompensa[i].activeSelf);
            }
            etapa = 0;
            inventoryManager.CloseBackPack();
        }
        if (cucaBossFight)
        {
            if (recompensa.Length > 0)
            {
                for (int i = 0; i < recompensa.Length; i++)
                {
                    recompensa[i].SetActive(!recompensa[i].activeSelf);
                }
            }
            // tirar comentario da linha abaixo caso exista algum item para ser ativado quando a cuca for derrotada
            //recompensa.SetActive(!recompensa.activeSelf);
            cuca.Derrota();
            inventoryManager.CloseBackPack();
        }
    }
}