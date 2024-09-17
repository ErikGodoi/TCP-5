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

    [SerializeField] int matintaGritos = 0;
    [SerializeField] float intervaloGrito = 5f;

    private void Start()
    {
        StartCoroutine(GritarComIntervalo());
    }

    private void GritoSupremo()
    {
        StartCoroutine(Shake());

        if (matintaGritos == 0)
        {
            MoverUrutaus(urutausMatinta1);
        }
        else if (matintaGritos == 1)
        {
            MoverUrutaus(urutausMatinta2);
        }
        else if (matintaGritos == 2)
        {
            MoverUrutaus(urutausMatinta3);
        }

        matintaGritos = Mathf.Min(matintaGritos + 1, 2);
    }

    private void MoverUrutaus(GameObject[] urutaus)
    {
        foreach (GameObject urutauObj in urutaus)
        {
            UrutauMatinta urutauScript = urutauObj.GetComponent<UrutauMatinta>();
            if (urutauScript != null)
            {
                urutauScript.VoarAleatoriamente(this.transform);
            }
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

    IEnumerator GritarComIntervalo()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloGrito);
            GritoSupremo();
            Debug.Log("Matinta Gritou");
        }
    }
}
