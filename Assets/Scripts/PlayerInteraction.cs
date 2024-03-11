using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory playerInventory;

    private void Update()
    {
        // Usar EventSystem para fazer com que o input seja quando o objeto é selecionado ao inves de Keycode.U
        // Example: Use the selected item when a specific key is pressed
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Provide the target GameObject as an example (replace with your own logic)
            GameObject targetObject = FindTargetObject();
            if (targetObject != null)
            {
                playerInventory.UseSelectedItem(targetObject);
            }
        }
    }

    private GameObject FindTargetObject()
    {
        // Implement your logic to find the target object in the game
        // For example, raycasting or checking the player's surroundings
        // Replace this with your actual logic based on your game design
        return null;
    }
}
