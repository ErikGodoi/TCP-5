using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChairsPuzzle : MonoBehaviour
{
    [SerializeField] List<GameObject> chairs = new List<GameObject>();
    //1 - 2
    //3 - 4
    [SerializeField] CircleCollider2D[] areaColliders = new CircleCollider2D[4];
    [SerializeField] WarehouseTrigger warehouseTrigger;

    [SerializeField] bool chairsInPlace = false;
    [SerializeField] bool puzzleSolved = false;

    private void Start()
    {
        warehouseTrigger = FindAnyObjectByType<WarehouseTrigger>();
    }

    private void Update() 
    {
        //Don't call in the update here, but when the chairs move only
        ChairsPositionCheck();

    }

    private void ChairsPositionCheck()
    {
        if(puzzleSolved)
        {
            return;
        }

        for (int i = 0; i < chairs.Count ; i++)
        {
            BoxCollider2D chairCollider = chairs[i].GetComponent<BoxCollider2D>();
            CircleCollider2D areaCollider = areaColliders[i];

            if(!IsColliding(chairCollider,areaColliders[i]))
            {
                Debug.Log($"Cadeira_{i} NÃO está na área correspondente: {i}");
                chairsInPlace = false;
                return;
            }
        }

        //Caso nenhuma esteja fora do lugar, ele sai do loop
        Debug.Log("Todas as cadeiras estão nas áreas correspondentes.");
        chairsInPlace = true;
        PuzzleSolved();
    }

    private void PuzzleSolved()
    {
        if(chairsInPlace && !puzzleSolved)
        {
            warehouseTrigger.incrementSteps(1);
            this.puzzleSolved = true;
            return;
        }
    }

    bool IsColliding(BoxCollider2D a, CircleCollider2D b)
    {
        // Check if the bounds of the two colliders intersect
        return a.bounds.Intersects(b.bounds);
    }
}
