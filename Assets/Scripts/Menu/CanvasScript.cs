using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [Header("Este Script só é utilizado para encontrar a camera na cena e não destruir quando muda de cena.")]
    public static CanvasScript instance = null;

    public Canvas canvas;
    public Camera cam;
    [Header("Chamar a função TrocarCena(); sempre que mudar uma cena do jogo.")]
    public bool trocouDeCena;

    [Header("Livro de Receitas")]
    public GameObject livro;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        canvas = GetComponent<Canvas>();
        livro.SetActive(false);
        trocouDeCena = true;
        TrocarCena();
    }
    public void TrocarCena()
    {
        if (trocouDeCena)
        {
            cam = FindAnyObjectByType<Camera>();
            canvas.worldCamera = cam;
            trocouDeCena = false;
        }
    }
    public void FecharLivro()
    {
        livro.SetActive(false);
    }
}
