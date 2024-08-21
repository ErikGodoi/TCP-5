using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarMochila : MonoBehaviour
{
    public GameObject sapoMochila;
    public GameObject nevoa;
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
            gameObject.SetActive(false);
        }
    }
}
