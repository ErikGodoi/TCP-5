using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleitemDisplay : MonoBehaviour
{
    public PuzzleItens puzzleItem;

    SpriteRenderer itemImage;
    void Start()
    {
        itemImage = GetComponent<SpriteRenderer>();
        itemImage.sprite = puzzleItem.sprite;

        gameObject.GetComponent<BoxCollider2D>().isTrigger = puzzleItem.colisorTrigger;
    }
}
