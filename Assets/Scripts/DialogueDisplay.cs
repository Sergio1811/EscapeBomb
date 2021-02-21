using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour
{
    public DialogueScriptable firstDialogue;
    public GameObject conversation;
    public GameObject options;
    public Transform parent;
    public Transform[] positionElection;
    DialogueScriptable currentDialogueScriptable;
    List<GameObject> currentElections = new List<GameObject>();
    void Start()
    {
        currentDialogueScriptable = firstDialogue;
        DisplayConversation();

    }

    public void DisplayConversation()
    {
        foreach (var item in currentElections)
        {
            Destroy(item);
            
        }
        currentElections.Clear();

        GameObject dialogue = Instantiate(conversation, parent);
        dialogue.GetComponent<TextAnimSimple>().dialogue= currentDialogueScriptable.question;
        dialogue.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = currentDialogueScriptable.charName;

        Button botonTemp=dialogue.transform.GetChild(1).GetComponent<Button>();
        if (currentDialogueScriptable.dialogueOptions.Length == 0)
        {
            botonTemp.onClick.AddListener(
               delegate
               {
                   currentDialogueScriptable = firstDialogue;
                   SpecialOcasionsDialogue();
                   Destroy(dialogue);
               });
        }
        else
        {
            botonTemp.onClick.AddListener(
                delegate
            {
                SpecialOcasionsDialogue();
                DisplayElections();
                Destroy(dialogue);

            });
        }

     
    }

    public void DisplayElections()
    {
            
        for (int i = 0; i < currentDialogueScriptable.dialogueOptions.Length; i++)
        {
            DisplayElection(positionElection[i], currentDialogueScriptable.dialogueOptions[i].optionLine, currentDialogueScriptable.dialogueOptions[i].nextDialogue);
        }
    }

    public void DisplayElection(Transform l_parent, string textOpt, DialogueScriptable nextDialogue)
    {
        GameObject election = Instantiate(options, l_parent);
        election.GetComponent<TextAnimSimple>().dialogue = textOpt;
        election.GetComponentInChildren<Button>().onClick.AddListener(
            delegate
            {
                currentDialogueScriptable = nextDialogue;

                DisplayConversation();
            });

        currentElections.Add(election);
    }

    public void SpecialOcasionsDialogue()
    {
        switch (currentDialogueScriptable.specialAction)
        {
            case "UnlockRecepcion":
                MenuController.instance.InstantiateNotification("Nueva ubicación desbloqueada: Recepción");
                DataHolder.instance.recepcion.SetActive(true);
                break;
            case "UnlockVideojuegos":
                MenuController.instance.InstantiateNotification("Nueva ubicación desbloqueada: Tienda de videojuegos");
                DataHolder.instance.videojuegos.SetActive(true);
                break;
            case "UnlockPeluqueria":
                MenuController.instance.InstantiateNotification("Nueva ubicación desbloqueada: Tienda de videojuegos");
                DataHolder.instance.videojuegos.SetActive(true);
                break;
            default:
                break;
        }
    }
}
