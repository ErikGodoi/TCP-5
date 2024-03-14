using UnityEngine;

[CreateAssetMenu(menuName = "New Item", fileName = "Inventory/New Item")]
public class PuzzleItens : ScriptableObject
{
    public int Index; // Gambiarra

    public string itemName;

    public Sprite sprite;

    public bool puzzleItem; // pode ser usado para resolver o puzzle

    public bool colisorTrigger; // se o colisor do item é um trigger ou não

    public int quantidade; // se for possivel ter mais de 1 do mesmo item

    public bool stackable; // se o item pego tiver mais de 1 do mesmo, se eles pode existir mais de 1 deles no mesmo slot

    // O que acontece quando o item é usado
    public virtual void UseItem(GameObject target)
    {
        // Implement item usage logic here
        Debug.Log("Used " + itemName + " on " + target.name);
    }
}
