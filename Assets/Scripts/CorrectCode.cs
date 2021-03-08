using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CorrectCode : MonoBehaviour
{
    public Bomb bombZuloA;
    public GameObject buttonZuloA;
    public Bomb bombZulo3;
    public GameObject buttonZulo3;
    public Bomb bombServerA;
    public GameObject buttonServerA;
    public Bomb bombServer3;
    public GameObject buttonServer3;
    public string codeToMatch;
    public string codeToMatch2;
    public GameObject loadingRT;
    public GameObject back;
    public Button buttonConfioHacker;
    public Button buttonConfioComisario;
    bool firstTimeCandado;
    public void codeRight(TextMeshProUGUI l_CodeFilled)
    {
        if (!firstTimeCandado)
        {

            string codeFilled = l_CodeFilled.text;
            codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
            if (codeToMatch == codeFilled)
            {
                MenuController.instance.getInventory().addItemToList("DocPoli");
                MenuController.instance.InstantiateNotification("Nuevo Objeto: Hoja de sospechosos");
                firstTimeCandado = true;
            }
            else
            {
                MenuController.instance.InstantiateNotification("Parece que no es correcto.");
            }
        }
    }

    public void codeRightRT(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        if (codeToMatch == codeFilled)
        {
            loadingRT.SetActive(true);
            this.transform.parent.gameObject.SetActive(false);
            back.SetActive(false);
            DataHolder.instance.ui.SetActive(false);
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

    public void HackerOption(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;

        if (code == codeFilled)
        {
            buttonConfioHacker.interactable = true;
        }
    }

    public void ComisarioOption(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;

        if (code == codeFilled)
        {
            buttonConfioComisario.interactable = true;
        }
    }

    public void DesactivacionBombasZA(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombZuloA.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);
            buttonZuloA.SetActive(false);

        }
    }

    public void DesactivacionBombasZ3(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombZulo3.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);
            buttonZulo3.SetActive(false);
        }
    }

    public void DesactivacionBombasSA(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombServerA.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);
            buttonServerA.SetActive(false);
        }
    }

    public void DesactivacionBombasS3(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombServer3.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);
            buttonServer3.SetActive(false);

        }
    }
}

