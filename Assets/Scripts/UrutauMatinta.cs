using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutauMatinta : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] float velocidade = 2.0f;
    [SerializeField] float raioDeVoo = 5.0f;
    [SerializeField] float tempoEntreMovimentos = 2.0f;

    private Vector3 posicaoDestino;
    private Transform matintaTransform;

    void Start()
    {
        CalcularNovaPosicaoAleatoria();
    }

    void Update()
    {
        if (matintaTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoDestino, velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position, posicaoDestino) < 0.1f)
            {
                StartCoroutine(AguardarECalcularNovaPosicao());
            }
        }
    }

    public void VoarAleatoriamente(Transform matinta)
    {
        matintaTransform = matinta;
        CalcularNovaPosicaoAleatoria();
    }

    void CalcularNovaPosicaoAleatoria()
    {
        if (matintaTransform != null)
        {
            Vector2 direcaoAleatoria = Random.insideUnitCircle.normalized * raioDeVoo;
            posicaoDestino = matintaTransform.position + new Vector3(direcaoAleatoria.x, direcaoAleatoria.y, 0);
        }
    }

    IEnumerator AguardarECalcularNovaPosicao()
    {
        yield return new WaitForSeconds(tempoEntreMovimentos);
        CalcularNovaPosicaoAleatoria();
    }
}
