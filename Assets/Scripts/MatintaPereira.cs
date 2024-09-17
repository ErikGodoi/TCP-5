using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatintaPereira : MonoBehaviour
{
    [SerializeField] GameObject[] urutausMatinta1;
    [SerializeField] GameObject[] urutausMatinta2;
    [SerializeField] GameObject[] urutausMatinta3;

    public AnimationCurve curva;
    public float duracao;

    int matintaGritos;

    void Update()
    {
        
    }

    private void GritoSupremo()
    {
        Shake();

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
