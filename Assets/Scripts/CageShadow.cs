using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageShadow : MonoBehaviour
{
    public bool playerCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("JOGADOR COLIDIU COM A SOMBRA");
            playerCollided = true;
        }
    }
}
