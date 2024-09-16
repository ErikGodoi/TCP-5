using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarMochila : MonoBehaviour
{
    public Backpack sapoMochila;
    public GameObject nevoa;
    public GameObject nevoa2;
    public GameObject nevoa3;
    public ItemCollector colector;
    public GameManager gm;

    public SoundManager soundManager;
    bool temMochila;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sapoMochila = FindObjectOfType<Backpack>();
        colector = FindAnyObjectByType<ItemCollector>();
        if (sapoMochila.pegouAMochila == false)
        {
            sapoMochila.gameObject.SetActive(false);
        }
        else
        {
            gm.DesativarNevoa();
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
            colector.backPack = sapoMochila;
            sapoMochila.pegouAMochila = true;
            soundManager.PlaySound("somExemplo");
            sapoMochila.gameObject.SetActive(true);
            nevoa.gameObject.SetActive(false);
            nevoa2.gameObject.SetActive(false);
            nevoa3.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
