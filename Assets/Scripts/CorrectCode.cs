using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CorrectCode : MonoBehaviour
{
    public Bomb bombZuloC;
    public Bomb bombServerC;
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

    public DialogueDisplay libreriaDialogues;
    public DialogueScriptable dialogue3Libreria;

    public TextMeshProUGUI textA1;
    public Button nextA1;
    public TextMeshProUGUI textA2;
    public Button nextA2;
    public TextMeshProUGUI textA3;
    public Button nextA3;

    public TextMeshProUGUI textCR;
    public Button nextCR;
    public DialogueDisplay videojuegosDialogues;
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

    public void DesactivacionBombasSC(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombServerC.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);


        }
    }

    public void DesactivacionBombasZC(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            bombZuloC.BombaFinalizada();
            this.transform.parent.gameObject.SetActive(false);

        }
    }

    public void horaCorrect(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        print(codeFilled);
        print(code);
        if (code == codeFilled)
        {
            DataHolder.instance.correctHour = true;

        }
    }

    public void minuteCorrect(string code)
    {
        string codeFilled = this.GetComponent<TMP_InputField>().text;
        if (code == codeFilled)
        {
            DataHolder.instance.correctMinute = true;

        }
    }

    public void Acertijo1(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        codeFilled = codeFilled.ToLower();

        if ("la almohada" == codeFilled || "almohada" == codeFilled)
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            MenuController.instance.acertijo2.SetActive(true);
        }

        else
        {
            string tempText;
            tempText = textA1.text;

            textA1.text = "Vaya…. no parecéis muy listos, os daré otra oportunidad.";
            nextA1.gameObject.SetActive(true);

            nextA1.onClick.AddListener(delegate
            {
                textA1.text = tempText;
                nextA1.gameObject.SetActive(false);
            });

            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }

    public void Acertijo2(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        codeFilled = codeFilled.ToLower();

        if ("don quijote" == codeFilled || "quijote" == codeFilled || "don quijote y sancho panza" == codeFilled)
        {
            MenuController.instance.acertijo2.SetActive(false);
            MenuController.instance.acertijo3.SetActive(true);
        }

        else
        {
            string tempText;
            tempText = textA2.text;

            textA2.text = "Vaya…. no parecéis muy listos, os daré otra oportunidad.";
            nextA2.gameObject.SetActive(true);

            nextA2.onClick.AddListener(delegate
            {
                textA2.text = tempText;
                nextA2.gameObject.SetActive(false);
            });

            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }

    public void Acertijo3(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        codeFilled = codeFilled.ToLower();

        if ("la 3" == codeFilled || "la tercera" == codeFilled || "la treh" == codeFilled || "tercera" == codeFilled || "3" == codeFilled || "tres" == codeFilled || "la tres" == codeFilled)
        {
            libreriaDialogues.firstDialogue = dialogue3Libreria;
            libreriaDialogues.DisplayConvMenu();
            MenuController.instance.acertijo3.SetActive(false);
        }

        else
        {
            string tempText;
            tempText = textA3.text;

            textA3.text = "Vaya…. no parecéis muy listos, os daré otra oportunidad.";
            nextA3.gameObject.SetActive(true);

            nextA3.onClick.AddListener(delegate
            {
                textA3.text = tempText;
                nextA3.gameObject.SetActive(false);
            });

            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }

    public void EjercicioCopyright(TextMeshProUGUI l_CodeFilled)
    {
        string codeFilled = l_CodeFilled.text;
        codeFilled = codeFilled.Substring(0, codeFilled.Length - 1);
        codeFilled = codeFilled.ToLower();

        if ("11" == codeFilled || "once" == codeFilled)
        {
            textCR.gameObject.transform.parent.gameObject.SetActive(true);
            textCR.text = "¡Si! Perfecto.";
            nextCR.gameObject.SetActive(true);

            nextCR.onClick.RemoveAllListeners();
            nextCR.onClick.AddListener(delegate
            {
                videojuegosDialogues.DisplayConvMenu();
                textCR.gameObject.transform.parent.gameObject.SetActive(false);
            });
    
            MenuController.instance.ejPokemon.SetActive(false);
        }

        else
        {

            textCR.text = "Vaya…. no parecéis muy listos, os daré otra oportunidad.";
            nextCR.gameObject.SetActive(true);

            nextCR.onClick.AddListener( delegate
                {
                    textCR.gameObject.transform.parent.gameObject.SetActive(false);
                });

            l_CodeFilled.text = null;
            l_CodeFilled.ForceMeshUpdate(true);
        }
    }
}

