using UnityEngine;


[CreateAssetMenu(fileName = "Dialogue", menuName ="Dialogue")]
public class DialogueScriptable : ScriptableObject
{
    public string charName;
    public string question;
    public string specialAction; //Dejar en blanco si no pada nada

    public Option[] dialogueOptions;
}

[System.Serializable]
public struct Option
{
    public string optionLine;
    public DialogueScriptable nextDialogue;
    public string specialAction; //Dejar en blanco si no pasa nada
}
