using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarMochila : MonoBehaviour
{
    public GameObject sapoMochila;
    public GameObject nevoa;
    public GameObject nevoa2;
    public GameObject nevoa3;
    void Start()
    {
        sapoMochila.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sapoMochila.SetActive(true);
            nevoa.gameObject.SetActive(false);
            nevoa2.gameObject.SetActive(false);
            nevoa3.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
