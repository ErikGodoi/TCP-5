using UnityEditor;

public static class ExitCreateUtility
{
    [MenuItem("GameObject/ExitPrefab")]
    public static void CreateDialogueCanvas(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("exitTo");
    }
}
