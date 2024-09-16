using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [Header("Nome da cena pra qual o jogador vai")]
    [Tooltip("Escreve o nome da cena CERTO KCT")]
    public string sceneName;
    [Header("Nome da Sala onde o jogador vai aparecer")]
    public string nomeDaNovaSala;
    [Header("Nova Posição do jogador")]
    public Vector2 novaPos;
    GameManager gm;
    private void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            collision.gameObject.transform.position = novaPos;
            gm.TrocarCena(nomeDaNovaSala);
        }
    }
    
}
