using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urutau : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minimalDistance;

    bool seguindo;

    public bool pegarPresente;
    public Vector2 presentePos;
    public bool IsFollowing => seguindo;


    Vector3 keepKoing;

    Rigidbody2D rb;

    Transform jogador;

    PlayerUrutau playerScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        keepKoing = new Vector3(jogador.position.x + Random.Range(-1, 1f), jogador.position.y + Random.Range(-1, 1f), 0) - transform.position;
        keepKoing = keepKoing.normalized;
    }
    private void FixedUpdate()
    {
        if (seguindo)
        {
            if (Vector2.Distance(transform.position, jogador.position) >= minimalDistance)
            {
                Vector3 direcao = jogador.position - transform.position;
                direcao = direcao.normalized;

                rb.velocity = direcao * speed * Time.deltaTime;

                keepKoing = new Vector3(jogador.position.x + Random.Range(-1, 1f), jogador.position.y + Random.Range(-1, 1f), 0) - transform.position;
                keepKoing = keepKoing.normalized;
            }
            else
            {
                rb.velocity = speed * Time.deltaTime * keepKoing;
            }
        }
        if (pegarPresente)
        {
            PegarPresente(presentePos);
        }
    }
    public void PegarPresente(Vector2 presente)
    {
        transform.position = Vector2.MoveTowards(transform.position, presente, Time.deltaTime * speed);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        seguindo = false;
        gameObject.tag = "Urutau";
        
    }
}
