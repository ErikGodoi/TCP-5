using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUrutau : MonoBehaviour
{
    int urutauSeguindo;
    public void AddUrutau()
    {
        urutauSeguindo++;
    }
    public void ClearUrutau()
    {
        urutauSeguindo = 0;
    }
    public void RemoveUrutau()
    {
        if (urutauSeguindo <= 0)
        {
            return;
        }
        urutauSeguindo--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Presente") && urutauSeguindo > 0)
        {
            RemoveUrutau();

            GameObject[] urutaus = GameObject.FindGameObjectsWithTag("UrutauSeguindo");
            int random = Random.Range(0, urutaus.Length);

            urutaus[random].GetComponent<Urutau>().pegarPresente = true;
            urutaus[random].GetComponent<Urutau>().presentePos = collision.gameObject.transform.position;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // fazer um urutau aleatorio parar de seguir o player e pegar o presente
        }
    }
}
