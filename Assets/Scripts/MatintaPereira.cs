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

    [SerializeField] int matintaGritos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GritoSupremo();
        }
    }

    private void GritoSupremo()
    {
        Shake();

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
            Urutau urutauScript = urutauObj.GetComponent<Urutau>();
            if (urutauScript != null)
            {
                //urutauScript.MoverComGritoAleatorio();
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
}
