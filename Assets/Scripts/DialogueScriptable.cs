using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue", menuName ="Dialogue")]
public class DialogueScriptable : ScriptableObject
{
    public string charName;
    public string question;
    public Option[] dialogueOptions;
}

[System.Serializable]
public struct Option
{
    public string optionLine;
    public DialogueScriptable nextDialogue;
}
