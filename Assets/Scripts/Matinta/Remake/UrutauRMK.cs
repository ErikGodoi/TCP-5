using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutauRMK : MonoBehaviour
{
    [Header("Objetivo serve para marcar um objeto para onde o urutau vai")]
    public GameObject objetivo;

    Vector2 posicaoInicial;
    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        
    }
}
