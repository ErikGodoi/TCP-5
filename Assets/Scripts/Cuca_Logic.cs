using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca_Logic : MonoBehaviour
{
    [Header("Atributos da Cuca")]
    [Tooltip("Velocidade de Movimento")]
    public float velocidade;
    [Tooltip("Quanto tempo o jogador fica parado quando a cuca molesta o jogador")]
    public float tempoDaPEGADA;
    [Tooltip("Quanto tempo a cuca fica estunada dps de molestar o jogador(3s = 3s parado depois do jogador poder se mexer)")]
    public float tempoDeStun;
    public float balangadaPorSegundo;
    float stun;
    bool perseguir;
    bool forro;
    PlayerController jogador;

    Vector3 initialRotation1;
    Vector3 initialRotation2;
    void Start()
    {
        jogador = FindObjectOfType<PlayerController>();
        initialRotation1 = transform.eulerAngles;
        initialRotation2 = jogador.transform.eulerAngles;
    }
    void Update()
    {
        if (stun > 0)
        {
            stun -= Time.deltaTime;
            perseguir = false;
        }
        else
        {
            perseguir = true;
        }
        if (perseguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, jogador.transform.position, Time.deltaTime * velocidade);
        }
        if (forro)
        {
            StartCoroutine(Balanca());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(jogador.JogadorPego(tempoDaPEGADA));
            stun = tempoDaPEGADA + tempoDeStun;
            forro = true;
        }
    }
    IEnumerator Balanca()
    {
        float timeElapsed = 0f;

        while (timeElapsed < tempoDeStun)
        {
            float angle = Mathf.Sin(timeElapsed * balangadaPorSegundo * 2 * Mathf.PI) * 5;
            transform.eulerAngles = new Vector3(initialRotation1.x, initialRotation1.y, initialRotation1.z + angle);
            jogador.transform.eulerAngles = new Vector3(initialRotation2.x, initialRotation2.y, initialRotation2.z + angle);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = initialRotation1;
        jogador.transform.eulerAngles = initialRotation2;
        forro = false;
    }
}
