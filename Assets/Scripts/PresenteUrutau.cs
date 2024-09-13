using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenteUrutau : MonoBehaviour
{

    public int urutauReq;

    public PlayerUrutau playerUrutau;

    public bool evento;
    public float velocidade;
    public Vector2 posObjetivo;
    public float velRotacao;
    public Quaternion rotacaoObjetivo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerUrutau player = collision.gameObject.GetComponent<PlayerUrutau>();
        if(player.urutauSeguindo >= urutauReq)
        {
            Debug.Log("Presente consumido com sucesso!");

            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Não tem urutaus seguindo o suficiente");
        }
    }
    public void FixedUpdate()
    {
        AcionarEvento();
    }
    public void AcionarEvento()
    {
        if (evento)
        {
            transform.position = Vector2.MoveTowards(transform.position, posObjetivo, Time.deltaTime * velocidade);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacaoObjetivo, velRotacao);
        }
    }
}
