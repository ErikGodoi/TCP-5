using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways] //Executar o código no editor;
public class DialogueTrigger : MonoBehaviour
{
    [Header("Selecione o DialogueHolder e o Manager")]
    [SerializeField] DialogueHolder dialogueHolder;
    [SerializeField] DialogueManager dialogueManager;

    DialogueHolder.Dialogue thisDialogue;
    
    [Header("Defina a primeira e ultima fala dessa interação:")]
    [SerializeField] string dialogueStartId;
    [SerializeField] string dialogueEndId;
    private int dialogueStartIndex;
    private int dialogueEndIndex;

    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        if(dialogueHolder != null) //Checks if you setted Manager and Holder
        {
            thisDialogue = dialogueHolder.GetDialogue();
            dialogueStartIndex = dialogueHolder.GetDialogueIndex(dialogueStartId);
            dialogueEndIndex = dialogueHolder.GetDialogueIndex(dialogueEndId);
        }
        
        NoParentError(); //if hasn't parent
        DialogueObjectsError(); //if objects aren't setted
        DialogueIDError(); // if the ID is wrong
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Diálogo ativado: " + collider.gameObject.name);
            dialogueManager.DialogueStart(thisDialogue, dialogueStartIndex, dialogueEndIndex);
        }
    }

    private void DialogueIDError()
    {
        if(dialogueStartIndex == -1 || dialogueEndIndex == -1)
        {
            Debug.LogError("ID das falas não definido ou definido incorretamente!" +
            $"\n Por favor verifique o trigger de: {this.gameObject.transform.parent.name}");
        }
    }

    private void NoParentError()
    {
        if(this.gameObject.transform.parent == null)
        {
            Debug.LogError("Triggers precisam ser filhos de outro objeto!" +
            $"\n Por favor defina um parent");
        }
            
    }
    private void DialogueObjectsError()
    {
        if(dialogueHolder == null || dialogueManager == null)
        {
            Debug.LogError("Dialogue Holder ou Manager não encontrados!" +
            $"\n Por favor verifique no trigger de: {this.gameObject.transform.parent.name}");
        }
    }

}

