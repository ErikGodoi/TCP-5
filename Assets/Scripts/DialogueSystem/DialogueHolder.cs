using System;
using System.Data.Common;
using System.IO;
using UnityEngine;

[ExecuteAlways] //Executar o código no editor;
public class DialogueHolder : MonoBehaviour
{
    [Header("Insira o nome do arquivo de diálogo")]
    [SerializeField] string dialogueName = "";
    [SerializeField] string filePath = "Assets/Resources/Dialogues/";

    [Header("Recarregue o diálogo")]
    [SerializeField] bool refresh = false;

    [SerializeField] Dialogue thisDialogue = new Dialogue();

    [System.Serializable]
    public class DialogueLine //representation of each line of a dialog file
    {
        public string id;
        public string character;
        public string[] options;
        public string[] goTo;
        public string text;
        public bool isEnd;
    }

    [System.Serializable]
    public class Dialogue //here are stored all lines of dialogue
    {
        public DialogueLine[] dialogueLines;
    }
    
    void Start()
    {
        LoadDialogueJSON();
    }
    
    void Update()
    {
        if(refresh)
        {
            ChangeDialogue(dialogueName);
            refresh = false;
        }       
    }

    public void LoadDialogueJSON()
    {
        try
        {
            string jsonString = File.ReadAllText(filePath + dialogueName + ".json");
            thisDialogue = JsonUtility.FromJson<Dialogue>(jsonString);
            
            Debug.Log($"Loaded dialogue:\n {dialogueName}");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

    public Dialogue GetDialogue()
    {
        return thisDialogue;
    }
    
    public void ChangeDialogue(string newDialogueName)
    {
        //change the current dialogue script and reload it
        this.dialogueName = newDialogueName;
        LoadDialogueJSON();
    }

    public int GetDialogueIndex(string id)
    {
        for (int i = 0; i < thisDialogue.dialogueLines.Length; i++)
            {
                if (thisDialogue.dialogueLines[i].id == id)
                {
                     return i; //index of the dialogueLine
                }
            }
            return -1; //Out of Bounds
    }

}