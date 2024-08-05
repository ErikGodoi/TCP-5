using System;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private CageShadow shadowScript;

    public GameObject cageObject;
    public CageState state;
    public static event Action<CageState> OnCageStateChanged;

    [SerializeField] private int clickCount = 0;
    [SerializeField] private int maxClicks = 5;

    public enum CageState
    {
        Inactive,
        Active,
        Destroyed
    }

    private void Start()
    {
        state = CageState.Inactive;

        // Léo do futuro, por favor, conserte isso. Obrigado.
        shadowScript = GetComponentInIParent<CageShadow>();
        rb = GetComponent<Rigidbody2D>();

        UpdateCageState(state); // Inicializa o estado
    }

    private void Update()
    {
        HandleClick();
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
        rb.gravityScale = 1;
    }

    private void HandleDestroyed()
    {
        cageObject.SetActive(false);
        Debug.Log("JAULA DESTRUÍDA");
        // Adicionar lógica adicional para quando a jaula é destruída, se necessário
    }

    private void HandleClick()
    {
        if (state == CageState.Active && Input.GetMouseButtonDown(0))
        {
            clickCount++;
            Debug.Log($"Jaula clicada {clickCount} vezes.");

            if (clickCount >= maxClicks)
            {
                UpdateCageState(CageState.Destroyed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shadow"))
        {
            // Implementar comportamento quando a jaula colide com o objeto "Shadow"
        }
    }
}
