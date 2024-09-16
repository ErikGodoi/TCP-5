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
    PlayerController pC;
    InventoryManager inventory;
    public SceneChanger[] sceneChangers;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        pC = FindAnyObjectByType<PlayerController>();
        gm = FindAnyObjectByType<GameManager>();
        canvas = FindAnyObjectByType<CanvasScript>();
        inventory = FindAnyObjectByType<InventoryManager>();
        sceneChangers[0] = gameObject.GetComponent<SceneChanger>();
        sceneChangers = FindObjectsOfType<SceneChanger>();
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
        pC.parado = true;
        gm.transicao.SetActive(true);
        yield return new WaitForSeconds(1);
        canvas.TrocarCena();
        inventory.ClearInventory();
        gm.DesativarTrocaDeCena();
        gm.PortalDeVolta();
        gm.NovaCam();
        gm.ChangeRoom(nomeDaNovaSala);
        gm.transicao.SetActive(false);
        pC.parado = false;
        for (int i = 0; i < sceneChangers.Length; i++)
        {
            Destroy(sceneChangers[i].gameObject);
        }
    }
}
