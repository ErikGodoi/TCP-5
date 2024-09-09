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
    CanvasScript canvas;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        canvas = FindAnyObjectByType<CanvasScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            collision.gameObject.transform.position = novaPos;
            StartCoroutine(Espera());
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1);
        canvas.TrocarCena();
        gm.DesativarTrocaDeCena();
        gm.PortalDeVolta();
        gm.NovaCam();
        gm.ChangeRoom(nomeDaNovaSala);
        Destroy(gameObject);
    }
}
