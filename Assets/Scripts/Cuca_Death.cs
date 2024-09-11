using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca_Death : MonoBehaviour
{
    public float rotationAmount = 10f; // Quantidade de rotação no eixo Z
    public int rotationRepetitions = 5; // Número de repetições da rotação de -10 a 10 graus
    public float finalRotation = 90f; // Rotação final no eixo Z
    public float delayBeforeDisappearing = 2f; // Tempo antes de o objeto desaparecer
    GameManager gm;
    private void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    public void Morte()
    {
        StartCoroutine(RotateObject());
    }
    private IEnumerator RotateObject()
    {
        Quaternion startRotation = transform.rotation;

        // Rotação de -10 a 10 graus, repetida 5 vezes
        for (int i = 0; i < rotationRepetitions; i++)
        {
            yield return StartCoroutine(RotateToAngle(startRotation, -rotationAmount));
            yield return StartCoroutine(RotateToAngle(startRotation, rotationAmount));
        }

        // Rotação final para 90 graus
        yield return StartCoroutine(RotateToFinalAngle(startRotation, finalRotation));

        // Esperar por 2 segundos
        yield return new WaitForSeconds(delayBeforeDisappearing);

        gm.ativarPortal = true;
        gm.PortalDeVolta();
        // Desativar o objeto
        gameObject.SetActive(false);
    }

    private IEnumerator RotateToAngle(Quaternion startRotation, float angle)
    {
        float time = 0.5f; // Tempo que leva para fazer a rotação
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 0, angle);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    private IEnumerator RotateToFinalAngle(Quaternion startRotation, float angle)
    {
        float time = 1f; // Tempo que leva para fazer a rotação final
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
