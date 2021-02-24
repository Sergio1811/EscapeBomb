using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectCode : MonoBehaviour
{
    public string codeToMatch;
    public string codeToMatch2;
    public GameObject loadingRT;

  public void codeRight(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch==codeFilled)
        {
            MenuController.instance.getInventory().addItemToList("DocPoli");
            MenuController.instance.InstantiateNotification("Nuevo Objeto: Hoja de sospechosos");
            print("funiono");
        }
    }
    
    public void codeRightRT(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch==codeFilled)
        {
            loadingRT.SetActive(true);
            print("funiono");
        }
    }

    public void CorrectHacker(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch == codeFilled || codeToMatch2 == codeFilled)
        {
            MenuController.instance.InstantiateNotification("Nombre correcto.");
            MenuController.instance.sospechosos = MenuController.instance.hacker;
        }
        else
        {
            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }


}
