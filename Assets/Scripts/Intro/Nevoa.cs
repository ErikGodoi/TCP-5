using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nevoa : MonoBehaviour
{
    public GameObject[] nevoas;
    public Vector2[] dispersar;
    public float velocidade;
    bool comecar;
    float desativar = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            comecar = true;
            desativar = 15;
        }
    }
    void Update()
    {
        if (comecar)
        {
            DispersarNevoa();
        }
        if (desativar >= 0)
        {
            desativar -= Time.deltaTime;
        }
        if (desativar < 0)
        {
            Destroy(gameObject);
        }
    }
    void DispersarNevoa()
    {
        for (int i = 0; i < nevoas.Length; i++)
        {
            nevoas[i].transform.position = Vector2.MoveTowards(nevoas[0].transform.position, dispersar[i], Time.deltaTime * velocidade);

        }
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < nevoas.Length; i++)
        {
            nevoas[i].gameObject.SetActive(false);
        }
    }
}
