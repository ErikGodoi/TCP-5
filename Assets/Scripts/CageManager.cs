using System;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    private CageShadow shadowScript;

    public GameObject cageObject;
    public CageState state;
    public static event Action<CageState> OnCageStateChanged;

    [SerializeField] private int clickCount = 0;
    [SerializeField] private int maxClicks = 5;

    float objectY;

    public float fallSpeed = 5f;

    public PlayerController player;

    public enum CageState
    {
        Inactive,
        Active,
        Destroyed
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        objectY = transform.position.y;
        state = CageState.Inactive;

        // Léo do futuro, por favor, conserte isso. Obrigado.
        shadowScript = GetComponentInParent<CageShadow>();

        UpdateCageState(state); // Inicializa o estado
    }

    private void Update()
    {
        if(state == CageState.Active)
        {
            HandleClick();
        }

        UpdateCageState(state);
    }

    public void UpdateCageState(CageState newState)
    {
        state = newState;
        OnCageStateChanged?.Invoke(newState);

        switch (newState)
        {
            case CageState.Inactive:
                HandleInactive();
                break;
            case CageState.Active:
                HandleActive();
                break;
            case CageState.Destroyed:
                HandleDestroyed();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    private void HandleInactive()
    {
        cageObject.SetActive(false);
    }

    private void HandleActive()
    {
        cageObject.SetActive(true);

        
        Vector2 fall = new Vector2 (transform.position.x, objectY -3.44f);
        transform.position = Vector2.MoveTowards(transform.position, fall, Time.deltaTime * fallSpeed);

        if(clickCount >= maxClicks)
        {
            state = CageState.Destroyed;
        }
    }

    private void HandleDestroyed()
    {
        clickCount = 0;
        player.parado = false;
        cageObject.SetActive(false);
        Debug.Log("JAULA DESTRUÍDA");
        // Adicionar lógica adicional para quando a jaula é destruída, se necessário
    }

    //Detecta os cliques do jogador
    private void HandleClick()
    {
        if (state == CageState.Active && Input.GetMouseButtonDown(0))
        {
            clickCount++;
            Debug.Log($"Jaula clicada {clickCount} vezes.");
        }
    }
}
