using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_1_Cuca : MonoBehaviour
{
    public GameObject rockFamily;
    public bool solucionado;
    void Start()
    {
        solucionado = false;
    }
    void Update()
    {
        if (solucionado)
        {
            rockFamily.SetActive(false);
        }
    }
}
