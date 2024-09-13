using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cortina : MonoBehaviour
{
    bool aberto = false;
    public Sprite closed;
    public Sprite open;

    public GameObject cortin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jogador(Clone)")
        {
            AbreFecha();
            gameObject.SetActive(false);
        }
    }
    public void AbreFecha()
    {
        if (!aberto)
        {
            cortin.GetComponent<SpriteRenderer>().sprite = open;
            aberto = false;
            cortin.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            cortin.GetComponent<SpriteRenderer>().sprite = closed;
            aberto = true;
        }
    }
}
