using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventoryManager playerInventory;
    public LayerMask interactionLayer; // Camada dos objetos com os quais o jogador pode interagir

    private void Update()
    {
        // Verifique se um item está selecionado e se houve um clique do mouse
        if (playerInventory.selectedItem != null && Input.GetMouseButtonDown(0))
        {
            // Encontre o objeto da cena com o qual o jogador quer interagir
            GameObject targetObject = FindTargetObject();

            // Se um objeto de interação foi encontrado, use o item selecionado nele
            if (targetObject != null)
            {
                playerInventory.UseSelectedItem(targetObject);
            }
        }
    }

    private GameObject FindTargetObject()
    {
        // Lança um raio a partir da posição do mouse na tela
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o raio atinge algum objeto na camada de interação
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactionLayer))
        {
            // Retorna o objeto atingido pelo raio
            Debug.Log(hit.collider.gameObject);
            return hit.collider.gameObject;
        }

        // Retorna nulo se nenhum objeto de interação for atingido
        return null;
    }
}
