using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    [SerializeField] bool isActive;

    private Rigidbody2D rb;

    private CageShadow shadowScript;

    private void Start()
    {
        // Léo do futuro, por favor conserte isso. Obrigado.
        shadowScript = GetComponentInChildren<CageShadow>();

        rb = GetComponent<Rigidbody2D>();

        isActive = false;
    }

    private void Update()
    {
        Active();
    }

    private void Active()
    {
        if (shadowScript.playerCollided == true)
        {
            Debug.Log("JAULA ATIVADA");
            isActive = true;
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shadow")
        {
            Caged();
        }
    }

    private void Caged()
    {
        //inserir código para o jogador poder destruir a jaula com 5 cliques
    }
}
