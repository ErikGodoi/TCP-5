using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Mov : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask collisionLayer;
    public float rayLength;

    public bool parado;
    // Troca de Cena
    public GameManager manager;

    // Animação
    public Animator animacao;

    // Point & Click Eu odeio todos vcs, vão se foderem
    public bool pointClick;
    public int speed;

    private Vector2 target;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        target = transform.position;
        pointClick = false;
        parado = false;
        manager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        animacao.SetFloat("Vertical", 0f);
        animacao.SetFloat("Horizontal", 0f);
        animacao.SetBool("Parado", true);
        if (pointClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            MovimentacaoEAnimacao();
        }
    }
    private void FixedUpdate()
    {
        if (pointClick)
        {
            velocity = (target - (Vector2)transform.position).normalized * speed * Time.fixedDeltaTime;
            if (Vector2.Distance(transform.position, target) > 0.05f)
            {
                transform.Translate(velocity, Space.World);
            }
        }
    }
    public void MovimentacaoEAnimacao()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(inputX, inputY);
        if (!parado)
        {
            MovePlayer(movement);
        }
        if (inputY != 0f)
        {
            inputX = 0;
        }
        else if(inputX != 0f)
        {
            inputY = 0;
        }
        if (inputY > 0)
        {
            // Indo para cima
            animacao.SetFloat("Vertical", 1f);
            animacao.SetBool("Parado", false);
        }
        else if (inputY < 0)
        {
            // Indo para baixo
            animacao.SetFloat("Vertical", -1f);
            animacao.SetBool("Parado", false);
        }
        if (inputX > 0)
        {
            // Indo para a direita
            animacao.SetFloat("Horizontal", 1f);
            animacao.SetBool("Parado", false);
        }
        else if (inputX < 0)
        {
            // Indo para a esquerda
            animacao.SetFloat("Horizontal", -1f);
            animacao.SetBool("Parado", false);
        }
        if (inputY == 0 && inputX == 0)
        {
            // Parado
            animacao.SetBool("Parado", true);
        }
    }
    private void MovePlayer(Vector2 movement)
    {
        // Perform raycasts in both horizontal and vertical directions
        bool canMoveHorizontal = CheckMovement(Vector2.right * movement.x);
        bool canMoveVertical = CheckMovement(Vector2.up * movement.y);

        // Move the player based on raycast results
        if (canMoveHorizontal)
        {
            transform.Translate(Vector2.right * movement.x * moveSpeed * Time.deltaTime);
        }

        if (canMoveVertical)
        {
            transform.Translate(Vector2.up * movement.y * moveSpeed * Time.deltaTime);
        }
    }
    private bool CheckMovement(Vector2 direction)
    {
        if (direction.y < 0)
        {
            //Ray lenght = 1.4
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength * 1.7f, collisionLayer);
            return hit.collider == null;
        }
        else if (direction.x < 0)
        {
            // Cast a ray in the specified movement direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength * 1.2f, collisionLayer);
            return hit.collider == null;
        }
        else if (direction.x > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength * 1.2f, collisionLayer);
            return hit.collider == null;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength, collisionLayer);
            return hit.collider == null;
        }
        // Check if there is a collider in the way
        //return hit.collider == null && hit.collider == null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Fase1"))
        {
            manager.fase1 = true;
            manager.fase2 = false;
            manager.fase3 = false;
            gameObject.transform.position = new Vector2(-1.5f, 0.5f);
            parado = true;
        }
        if (collision.gameObject.name.Contains("Fase2"))
        {
            manager.fase1 = false;
            manager.fase2 = true;
            manager.fase3 = false;
            gameObject.transform.position = new Vector2(17, 0);
            parado = true;
        }
        if (collision.gameObject.name.Contains("Fase3"))
        {
            manager.fase1 = false;
            manager.fase2 = false;
            manager.fase3 = true;
            gameObject.transform.position = new Vector2(50, -3.5f); 
            parado = true;
        }
    }
}
