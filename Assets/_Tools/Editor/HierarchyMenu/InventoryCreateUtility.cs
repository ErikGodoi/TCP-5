using UnityEditor;

public static class InventoryCreateUtility
{
    [MenuItem("GameObject/Inventory/InventoryCanvas")]
    public static void CreateDialogueCanvas(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("InventoryCanvas");
    }
}
