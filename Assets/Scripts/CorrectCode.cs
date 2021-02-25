using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectCode : MonoBehaviour
{
    public string codeToMatch;
    public string codeToMatch2;
    public GameObject loadingRT;
    public GameObject back;

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
        else
        {
            MenuController.instance.InstantiateNotification("Parece que no es correcto.");
        }
    }
    
    public void codeRightRT(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch==codeFilled)
        {
            loadingRT.SetActive(true);
            this.transform.parent.gameObject.SetActive(false);
            back.SetActive(false);
            DataHolder.instance.ui.SetActive(false);
            print("funciono");
        }
        else
        {
            MenuController.instance.InstantiateNotification("Parece que no es correcto.");
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
            DataHolder.instance.fotoHacker = true;
        }
        else
        {
            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }


}
