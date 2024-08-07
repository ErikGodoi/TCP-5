using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucaChase : MonoBehaviour
{
    public bool comecar;
    public AnimationCurve curva;
    public float duracao;
    public GameObject cuca;

    void Update()
    {
        if (comecar)
        {
            Instantiate(cuca, new Vector2(0, 50), Quaternion.identity);
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
