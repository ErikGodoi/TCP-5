using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saportal : MonoBehaviour
{
    public bool ativado = false;
    [Header("Espera é quanto tempo é necessário para os collider serem ativados dps que o sapo aparece em cena")]
    public float espera;
    [SerializeField]
    BoxCollider2D boxCollider;
    [SerializeField]
    BoxCollider2D boxCollider2;
    void Update()
    {
        Portal();
    }
    void Portal()
    {
        if (!ativado)
        {
            boxCollider.enabled = false;
            boxCollider2.enabled = false;
        }
        else
        {
            StartCoroutine(ativar());
        }
    }
    IEnumerator ativar()
    {
        yield return new WaitForSeconds(espera);
        boxCollider.enabled = true;
        boxCollider2.enabled = true;
    }
}
