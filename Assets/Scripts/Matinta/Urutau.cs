using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urutau : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minimalDistance;
    [SerializeField] float distanciaHorizontal;
    [SerializeField] float distanciaVertical;
    [SerializeField] int urutausReqGrito;

    bool seguindo;
    bool gritou;

    public bool pegarPresente;
    public Vector3 objPos1;
    public Vector3 objPos2;
    public bool IsFollowing => seguindo;

    Vector3 keepKoing;
    Vector3 posicaoOriginal;

    Rigidbody2D rb;

    Transform jogador;

    PlayerUrutau playerScript;

    [Tooltip("Esse objeto abaixo tem q ficar vazio em todos os urutaus exceto o da gaiola")]
    [Header("N coloca nada na caixa abaixo")]
    public GameObject urutauTelhado;
    public GameObject presenTelhado;
    public float presenteSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoOriginal = transform.position;
        playerScript = FindObjectOfType<PlayerUrutau>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !seguindo)
        {
            jogador = collision.transform;
            seguindo = true;
            gameObject.tag = "UrutauSeguindo";
            playerScript = collision.gameObject.GetComponent<PlayerUrutau>();
            if (playerScript != null)
            {
                playerScript.AddUrutau();
            }
            else
            {
                Debug.LogError("Script do Player não foi encontrado no GameObject Player");
            }
        }
        if (!seguindo && collision.gameObject.name == "Presente")
        {
            collision.gameObject.GetComponent<PresenteUrutau>().AcionarEvento();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        keepKoing = new Vector3(jogador.position.x + Random.Range(-1, 1f), jogador.position.y + Random.Range(-1, 1f), 0) - transform.position;
        keepKoing = keepKoing.normalized;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && urutausReqGrito >= playerScript.urutauSeguindo)
        {
            Grito();
        }
        if (seguindo)
        {
            if (urutauTelhado != null)
            {
                IrAoPresente();
            }
            if (Vector2.Distance(transform.position, jogador.position) >= minimalDistance)
            {
                Vector3 direcao = jogador.position - transform.position;
                direcao = direcao.normalized;

                rb.velocity = direcao * speed * Time.fixedDeltaTime;

                keepKoing = new Vector3(jogador.position.x + Random.Range(-1, 1f), jogador.position.y + Random.Range(-1, 1f), 0) - transform.position;
                keepKoing = keepKoing.normalized;
            }
            else
            {
                rb.velocity = speed * Time.fixedDeltaTime * keepKoing;
            }
        }
    }

    public void PegarPresente(Vector2 presente)
    {
        transform.position = Vector3.MoveTowards(transform.position, presente, Time.fixedDeltaTime * speed);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        seguindo = false;
        gameObject.tag = "Urutau";
    }

    public void Grito()
    {
        if (this.gameObject.tag == "UrutauSeguindo")
        {
            Debug.Log("O Urutau gritou!");
            
            GameObject[] urutauObjects = GameObject.FindGameObjectsWithTag("Urutau");

            foreach (GameObject urutau in urutauObjects)
            {
                Urutau urutauScript = urutau.GetComponent<Urutau>();
                if (urutauScript != null)
                {
                    if (gritou)
                    {
                        urutauScript.RetornarPosicaoOriginal();
                    }
                    else
                    {
                        urutauScript.MoverComGrito();
                    }
                }
            }

            gritou = !gritou;
        }
        else
        {
            Debug.Log("O Urutau não está seguindo, então não grita.");
        }
    }

    public void MoverComGrito()
    {
        transform.position += new Vector3(0, distanciaVertical, 0);
        transform.position += new Vector3(distanciaHorizontal, 0, 0);
    }

    public void RetornarPosicaoOriginal()
    {
        transform.position = posicaoOriginal;
    }

    public void IrAoPresente()
    {
        Vector3 targetPosition = new Vector3(objPos1.x, objPos1.y, urutauTelhado.transform.position.z);
        Vector3 targetPosition2 = new Vector3(objPos2.x, objPos2.y, urutauTelhado.transform.position.z); 
        if (presenTelhado.GetComponent<PresenteUrutau>().evento == true)
        {
            urutauTelhado.transform.position = Vector3.MoveTowards(urutauTelhado.transform.position, targetPosition2, Time.fixedDeltaTime * presenteSpeed);
        }
        else if (Vector3.Distance(urutauTelhado.transform.position, targetPosition) > 0.02f)
        {
            urutauTelhado.transform.position = Vector3.MoveTowards(urutauTelhado.transform.position, targetPosition, Time.fixedDeltaTime * presenteSpeed);
            if (Vector3.Distance(urutauTelhado.transform.position, targetPosition) < 0.02f)
            {
                pegarPresente = false;
                presenTelhado.GetComponent<PresenteUrutau>().evento = true;
                
            }
        }
    }
    private int GetUrutauSeguindoCount()
    {
        GameObject[] urutauSeguindo = GameObject.FindGameObjectsWithTag("UrutauSeguindo");
        return urutauSeguindo.Length;
    }
}
