using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public bool aberto = false;
    public Sprite open;
    public Sprite close;

    public GameObject inventoryBackground;
    public bool pegouAMochila;
    public void Botao()
    {
        if (aberto)
        {
            gameObject.GetComponent<Image>().sprite = close;
            inventoryBackground.SetActive(false);
            aberto = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = open;
            inventoryBackground.SetActive(true);
            aberto = true;
        }
    }
}
