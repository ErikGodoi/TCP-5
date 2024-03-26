using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Runtime.CompilerServices;

[ExecuteAlways] //Executar o código no editor;
public class DialogueManager : MonoBehaviour
{
    [Header("Objetos")]
    [SerializeField] GameObject dialogueParent;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Button option1Button;
    [SerializeField] Button option2Button;
    [SerializeField] Button nextButton;
    [Header("First Selected Options")]
    [SerializeField] private GameObject _dialogueMenuFirst;
    
    [Header("Velocidade do texto")]
    [SerializeField] float typingSpeed = 0.05f;

    private DialogueHolder.Dialogue dialogueList;

    [Header("Player")]
    [SerializeField] private PlayerController playerController;

    private int currentDialogueIndex = 0;

    void Start()
    {
        dialogueParent.SetActive(false);
    }

    public void DialogueStart(DialogueHolder.Dialogue textToPrint, int dialogueStartIndex, int dialogueEndIndex)
    {
        dialogueParent.SetActive(true);
        playerController.ChangeActionMaps("DialogueMenu"); //will change the actionMap and stop movement
        
        dialogueList = textToPrint;
        currentDialogueIndex = dialogueStartIndex;
        ShowButtons(false);

        StartCoroutine(PrintDialogue(dialogueEndIndex));
    }

    private void ShowButtons(bool showButtons)
    {
        //set buttons visibility and interactivity
        
        option1Button.interactable = showButtons;
        option2Button.interactable = showButtons;
        if(!showButtons)
        {
            option1Button.GetComponentInChildren<TMP_Text>().text = "";
            option2Button.GetComponentInChildren<TMP_Text>().text = "";
            nextButton.GetComponentInChildren<TMP_Text>().text = "Próximo";
        }
        else
        {
            nextButton.GetComponentInChildren<TMP_Text>().text = "";
        }

        EventSystem.current.SetSelectedGameObject(_dialogueMenuFirst); // seleciona o primeiro botão
    }

    private void SetButtonsText(DialogueHolder.DialogueLine dialogueLine)
    {
        if (dialogueLine.options != null && dialogueLine.options.Length == 2)
        {
            option1Button.GetComponentInChildren<TMP_Text>().text = dialogueLine.options[0];
            option2Button.GetComponentInChildren<TMP_Text>().text = dialogueLine.options[1];
        }
        else
        {
            // If options are not defined or there are not enough options, set empty text
            option1Button.GetComponentInChildren<TMP_Text>().text = "";
            option2Button.GetComponentInChildren<TMP_Text>().text = "";
        }
    }

    private bool optionSelected = false;

    private IEnumerator PrintDialogue(int dialogueEndIndex)
    {
        Debug.Log("Diálogo" +
        $"Inicio: {currentDialogueIndex}, Fim:{dialogueEndIndex}");
        while(currentDialogueIndex < dialogueEndIndex + 1)
        {
            DialogueHolder.DialogueLine line = dialogueList.dialogueLines[currentDialogueIndex];

            if(line.options != null && line.goTo != null && line.goTo.Length >= 2) //check if it has options of answer
            {
                yield return StartCoroutine(TypeText(line.text));
                
                ShowButtons(true);
                SetButtonsText(line);

                int goTo1 = GetDialogueIndex(line.goTo[0]);
                int goTo2 = GetDialogueIndex(line.goTo[1]);
                option1Button.onClick.AddListener(() => HandleOptionSelected(goTo1));
                option2Button.onClick.AddListener(() => HandleOptionSelected(goTo2));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                
                yield return StartCoroutine(TypeText(line.text));
                yield return new WaitUntil(() => playerController.nextPressed);
            }

            optionSelected = false;

            if (currentDialogueIndex > dialogueEndIndex)
            {
                yield return new WaitUntil(() => playerController.nextPressed);
            }
        }

        DialogueStop();

    }

    private void HandleOptionSelected(int goToIndex)
    {
        optionSelected = true;
        ShowButtons(false);

        currentDialogueIndex = goToIndex;
    }

    private IEnumerator TypeText(string text)
    {
        DialogueHolder.DialogueLine line = dialogueList.dialogueLines[currentDialogueIndex];
        dialogueText.text = "";
        foreach(char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if(line.options == null) //check if it hasn't any options
        {
            yield return new WaitUntil(() => playerController.nextPressed);
        }
        
        if(dialogueList.dialogueLines[currentDialogueIndex].isEnd)
        {
            DialogueStop();
        }

        currentDialogueIndex++;
        Debug.Log($"Incrementou current: {currentDialogueIndex}");
    }

    private void DialogueStop()
    {
        StopAllCoroutines(); //stop all text typing
        dialogueText.text = "";
        dialogueParent.SetActive(false);
        
        EventSystem.current.SetSelectedGameObject(null); //deseleciona
        playerController.ChangeActionMaps("Player"); //will change the actionMap to return movement
    }

    public int GetDialogueIndex(string id)
    {
        for (int i = 0; i < dialogueList.dialogueLines.Length; i++)
            {
                if (dialogueList.dialogueLines[i].id == id)
                {
                     return i; //index of the dialogueLine
                }
            }
            return -1; //Out of Bounds
    }

}
