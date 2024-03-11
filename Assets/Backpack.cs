using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public Sprite open;
    public Sprite close;

    public GameObject inventoryBackground;

    public void Botao()
    {
        Sprite atual = gameObject.GetComponent<Image>().sprite;
        if (atual == open)
        {
            gameObject.GetComponent<Image>().sprite = close;
            inventoryBackground.SetActive(false);
        }
        else if (atual == close)
        {
            gameObject.GetComponent<Image>().sprite = open;
            inventoryBackground.SetActive(true);
        }
    }
}
