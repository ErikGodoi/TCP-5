using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarMochila : MonoBehaviour
{
    public Backpack sapoMochila;
    public GameObject nevoa;
    public GameObject nevoa2;
    public GameObject nevoa3;
    bool temMochila;
    private void Start()
    {
        sapoMochila = FindObjectOfType<Backpack>();
        if (sapoMochila.pegouAMochila == false)
        {
            sapoMochila.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        temMochila = sapoMochila.gameObject.activeSelf;
        if (temMochila)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sapoMochila.pegouAMochila = true;
            sapoMochila.gameObject.SetActive(true);
            nevoa.gameObject.SetActive(false);
            nevoa2.gameObject.SetActive(false);
            nevoa3.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
