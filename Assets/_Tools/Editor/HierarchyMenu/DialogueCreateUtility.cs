using UnityEditor;

public static class DialogueCreateUtility
{
    [MenuItem("GameObject/Dialogue/DialogueCanvas")]
    public static void CreateDialogueCanvas(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("DialogueCanvas");
    }

    [MenuItem("GameObject/Dialogue/DialogueManager")]
    public static void CreateDialogueManager(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("DialogueManager");
    }

    [MenuItem("GameObject/Dialogue/DialogueHolder")]
    public static void CreateDialoguHolder(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("DialogueHolder");
    }

    [MenuItem("GameObject/Dialogue/DialogueTrigger")]
    public static void CreateDialogueTrigger(MenuCommand menuCommand)
    {
        CreateUtility.CreatePrefab("DialogueTrigger");
    }
}
