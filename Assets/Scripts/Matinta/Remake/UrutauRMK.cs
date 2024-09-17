using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutauRMK : MonoBehaviour
{
    [Header("Objetivo serve para marcar um objeto para onde o urutau vai")]
    public GameObject objetivo;

    int gritoReq;
    Urutau urutauParent;
    PlayerUrutau playerU;
    GameManager gm;
    Vector2 posicaoInicial;
    void Start()
    {
        urutauParent = GetComponent<Urutau>();
        posicaoInicial = transform.position;
        gm = FindAnyObjectByType<GameManager>();
        playerU = FindAnyObjectByType<PlayerUrutau>();
    }

    void Update()
    {
        GritoAtividade();
    }
    public void GritoAtividade()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playerU.urutauSeguindo >= gritoReq && gm.currentRoom == "Matinta_Room2")
            {
                //Vector3 targetPosition = new Vector3(objPos1.x, objPos1.y, urutauTelhado.transform.position.z);
                //Vector3 targetPosition2 = new Vector3(objPos2.x, objPos2.y, urutauTelhado.transform.position.z);
            }
            else if (playerU.urutauSeguindo >= gritoReq && gm.currentRoom == "Matinta_Room3")
            {
                urutauParent.seguindo = true;
            }
        }
    }
}
