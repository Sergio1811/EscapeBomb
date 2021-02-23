using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public string[] dialogues;
    public TextMeshProUGUI guiText;
    public float initialPause;
     float pause;
    public Button buttonNext;
    string message;
    int currentDialogue =0;
    void Start()
    {
        pause = initialPause;
        message = dialogues[currentDialogue];
        guiText.text = ""; // Clear the GUI text
        StartCoroutine(TypeLetters());
    }

    public void JumpAnimText()
    {
        pause = 0;
    }

    IEnumerator TypeLetters()
    {
        // Iterate over each letter
        foreach (char letter in message.ToCharArray())
        {
            guiText.text += letter; // Add a single character to the GUI text
            yield return new WaitForSeconds(pause);
        }

        if(currentDialogue!=0)
            buttonNext.onClick.RemoveAllListeners();

        pause = initialPause;
        currentDialogue++;

        if (currentDialogue >= dialogues.Length)
        {
            buttonNext.onClick.AddListener(
                delegate
                {
                    this.gameObject.SetActive(false);
                });
        }
        else
        {
            buttonNext.onClick.AddListener(
               delegate
               {
                   message = dialogues[currentDialogue];
                   guiText.text = "";
                   JumpAnimText();
                   StartCoroutine(TypeLetters());
               });
        }
    }
}
