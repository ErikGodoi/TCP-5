using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatintaChase : MonoBehaviour
{
    public bool comecar;
    public AnimationCurve curva;
    public float duracao;
    public GameObject matinta;

    void Update()
    {
        if (comecar)
        {
            Instantiate(matinta, new Vector2(0, 15), Quaternion.identity);
            comecar = false;
            StartCoroutine(Shake());
        }
    }
    IEnumerator Shake()
    {
        Vector2 posicaoInicial = transform.position;
        float tempo = 0f;

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            float forca = curva.Evaluate(tempo / duracao);
            transform.position = posicaoInicial + Random.insideUnitCircle * forca;
            yield return null;
        }
        transform.position = posicaoInicial;
    }
}
