using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectCode : MonoBehaviour
{
    public string codeToMatch;
    public GameObject loadingRT;

  public void codeRight(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch==codeFilled)
        {
            //dothings
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


}
