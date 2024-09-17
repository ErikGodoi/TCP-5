using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask collisionLayer;
    public float rayLength;
    
    public bool parado;

    //Input Actions
    private PlayerInput playerInput;
    private float horizontalMovement;
    private float verticalMovement;

    //Dialogue
    public bool nextPressed = false;
    public UnityEvent pressedEvent;
    
    // Troca de Cena
    public GameManager manager;

    // Point & Click
    public bool pointClick;
    public int speed;

    private Vector2 target;
    private Vector2 velocity = Vector2.zero;

    // Mover em direção da sombra
    public float towardShadowSpeed;
    Vector3 sombraPos;
    bool mTS;

    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        mTS = false;
        target = transform.position;
        pointClick = false;
        parado = false;
        manager = FindObjectOfType<GameManager>();
        if (pressedEvent == null)
                pressedEvent = new UnityEvent();
    }
    void Update()
    {
        moveToShadow();
        if (pointClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Move();
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
    public IEnumerator JogadorPego(float tempo)
    {
        parado = true;
        yield return new WaitForSeconds(tempo);
        parado = false;
        pegoPelaCuca = false;
    }
    public void SetMovementVector(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        verticalMovement = context.ReadValue<Vector2>().y;
    }
    public void NextPressed(InputAction.CallbackContext context)
    {
        if(context.started)
            nextPressed = true;
        if(context.canceled)
            nextPressed = false;
    }
    public void Move()
    {
        float inputX = horizontalMovement;
        float inputY = verticalMovement;
        Vector2 movement = new Vector2(inputX, inputY);
        if (!parado)
        {
            MovePlayer(movement);
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
        PlayerExit(collision);

        if (collision.gameObject.CompareTag("Shadow"))
        {
            sombraPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 1f, 0);
            mTS = true;
        }
    }
    private void moveToShadow()
    {
        if (mTS)
        {
            transform.position = Vector2.MoveTowards(transform.position, sombraPos, Time.deltaTime * towardShadowSpeed); 
            parado = true;
            if (transform.position == sombraPos)
            {
                mTS = false;
            }
        }
    }
    private void PlayerExit(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("exitTo"))
        {
            //parado = true;
            
            Exit exit = collision.gameObject.GetComponent<Exit>();
            manager.ChangeRoom(exit.nextRoom);

            this.transform.position = exit.playerNewPos;
        }
        if (collision.gameObject.name.Contains("exitTo_Cuca12"))
        {
            CucaChase chase = FindObjectOfType<CucaChase>();
            chase.comecar = true;
        }
    }
    private void PlayerCanMove(bool stop)
    {
        if(stop.Equals(typeof(PlayerController)))
        {

        }
        this.parado = stop;
    }
    public void ChangeActionMaps(string newActionMap)
    {
        playerInput.SwitchCurrentActionMap(newActionMap);
        switch (newActionMap)
        {
            case "Player":
                parado = false;
                break;
            case "DialogueMenu":
                parado = true;
                break;
        }
    }
}
