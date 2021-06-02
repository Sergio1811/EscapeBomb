using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimSimple : MonoBehaviour
{
    public string dialogue;
    public TextMeshProUGUI guiText;
    public float initialPause;
    void Start()
    {
        guiText.text = ""; // Clear the GUI text
        StartCoroutine(TypeLetters());
    }

    // Update is called once per frame

    IEnumerator TypeLetters()
    {
        // Iterate over each letter
        guiText.text = dialogue;
        /*foreach (char letter in dialogue.ToCharArray())
        {
            guiText.text += letter; // Add a single character to the GUI text
            yield return new WaitForSeconds(initialPause);
        }*/
        yield return null;
    }
    public void JumpAnimText()
    {
        initialPause = 0;
    }
}

