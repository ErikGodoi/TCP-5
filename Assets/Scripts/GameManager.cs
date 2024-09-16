using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("Objeto de transição de cena")]
    public GameObject transicao;
    [SerializeField] string currentRoom = "Cuca_Room1";
    
    public Camera cam;
    [SerializeField] Vector3 camPos;

    SceneChanger[] teleport;
    public GameObject saportal;
    public bool ativarPortal;

    [SerializeField]GameObject prefabPlayer;
    bool instPlayer;

    [SerializeField] GameObject[] nevoa;
    SceneChanger[] sceneChangers;

    CanvasScript canvas;
    PlayerController pC;
    InventoryManager inventory;
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
    public void DestroySceneChanger()
    {
        sceneChangers = FindObjectsOfType<SceneChanger>();
        for (int i = 0; i < sceneChangers.Length; i++)
        {
            Destroy(sceneChangers[i].gameObject);
        }
    }
    private void Start()
    {
        canvas = FindAnyObjectByType<CanvasScript>();
        inventory = FindAnyObjectByType<InventoryManager>();
        transicao.SetActive(false);
        //Inicia a camera para a posição da sala
        UpdateCam(currentRoom);
        cam = FindAnyObjectByType<Camera>();
        if (!instPlayer)
        {
            CriarJogador();
            instPlayer = true;
        }
    }
    void CriarJogador()
    {
        Vector3 posicaoInicial = new Vector3(0f, 10.46f, 0f);
        GameObject inst = Instantiate(prefabPlayer, posicaoInicial, Quaternion.identity);
        pC = inst.GetComponent<PlayerController>();
    }
    private void UpdateCam(string currentRoom)
    {
        camPos = GameObject.Find(currentRoom).transform.position;
        camPos.z = -10.0f;
        cam.transform.position = camPos;
    }

    public void ChangeRoom(string nextRoom)
    {
        currentRoom = nextRoom;
        UpdateCam(nextRoom);
    }
    public void NovaCam()
    {
        cam = FindAnyObjectByType<Camera>();
    }
    public void DesativarTrocaDeCena()
    {
        teleport = FindObjectsOfType<SceneChanger>();
        if (SceneManager.GetActiveScene().name == "Vila de Papelão")
        {
            for (int i = 0; i < teleport.Length; i++)
            {
                teleport[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < teleport.Length; i++)
            {
                teleport[i].gameObject.SetActive(false);
                if (teleport[i].gameObject.name == "sapo_portal")
                {
                    teleport[i].gameObject.SetActive(true);
                }
                if (teleport[i].gameObject.name == "SaidaVila")
                {
                    teleport[i].gameObject.SetActive(true);
                }
            }
        }
    }
    public void PortalDeVolta()
    {
        if (saportal == null) saportal = GameObject.Find("sapo_portal");
        if (saportal != null)
        {
            if (ativarPortal)
            {
                saportal.SetActive(true);
            }
            else
            {
                saportal.SetActive(false);
            }
        }
    }

    public void DesativarNevoa() 
    {
        GameObject nevoa1 = GameObject.Find("Névoa Matinta");
        GameObject nevoa2 = GameObject.Find("Névoa Loira");
        GameObject nevoa3 = GameObject.Find("Névoa Cuca");

        nevoa1.SetActive(false);
        nevoa2.SetActive(false);
        nevoa3.SetActive(false);
    }
    public void TrocarCena(string sala)
    {
        StartCoroutine(Espera(sala));
    }
    IEnumerator Espera(string sala)
    {
        pC.parado = true;
        transicao.SetActive(true);
        DestroySceneChanger();
        yield return new WaitForSeconds(1);
        canvas.TrocarCena();
        inventory.ClearInventory();
        DesativarTrocaDeCena();
        PortalDeVolta();
        NovaCam();
        ChangeRoom(sala);
        transicao.SetActive(false);
        pC.parado = false;
    }
}