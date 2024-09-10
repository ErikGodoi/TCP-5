using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenteUrutau : MonoBehaviour
{

    public int urutauReq;

    public PlayerUrutau playerUrutau;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerUrutau player = collision.gameObject.GetComponent<PlayerUrutau>();

        if(player != null && player.urutauSeguindo >= urutauReq)
        {
            Debug.Log("Presente consumido com sucesso!");

            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Não tem urutaus seguindo o suficiente");
        }
    }
}
