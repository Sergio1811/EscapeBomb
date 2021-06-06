using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    public GameObject ui;
    public int howManyObjectsINeed;
    public int currentObjectsINeed;

    public GameObject guarida;
    public GameObject merceria;
    public GameObject zulo;
    public GameObject salaServidor;
    public GameObject heladeria;
    public GameObject farmacia;
    public GameObject fruteria;
    public GameObject chipa;
    public GameObject libreria;
    public GameObject recepcion;
    public GameObject videojuegos;
    public GameObject peluqueria;
    public GameObject qePastelitos;

    public GameObject albaran;

    public bool hacker = false;
    public bool isPrinting = false;
    public GameObject videoFinalHacker;
    public GameObject videoFinalComisario;
    public GameObject bombPanel;
    public GameObject bombServers;
    public GameObject textBomb;
    public GameObject serverConv;

    #region
    [Header("Taxis")]
    public GameObject taxistaSeVa;
    public Sprite taxistaSeFue;
    public Image taxistaImage;
    public GameObject taxistaButton;
    public GameObject EscenaTaxiFueraInicial;
    public GameObject EscenaTaxiInterior;
    public GameObject EscenaTaxiFueraFinal;
    bool firstTime = false;
    public GameObject videoSalida;
    public enum SituacionTaxis
    {
        INICIAL, DENTRO, LLAVECORRECTA, FIN
    };

    public SituacionTaxis currentTaxiSituation = SituacionTaxis.INICIAL;
    #endregion

    [Header("")]
    public Button buttonLlave1;
    public Button buttonLlave2;
    public Button buttonLlave3;
    public Button buttonLlave4;
    public Button buttonLlave5;

    public enum UsingObject
    {
        NONE, ENDOSCOPIO, LLAVEMALA, LLAVEBUENA, MATRICULA, DOCTAXI, PC, FOTO
    }
    public UsingObject usingObject = UsingObject.NONE;
    public Sprite endoscopioSprite;
    public Sprite llaveSprite1;
    public Sprite llaveSprite2;
    public Sprite llaveSprite3;
    public Sprite llaveSprite4;
    public Sprite llaveBuenaSprite;
    public Sprite docTaxi;
    public Sprite matricula;
    public Sprite PC;
    public Sprite foto;

    [HideInInspector]
    public bool kitUsed;
    public bool qeUnclocked;

    public int bombsDesactivated;

    public bool fotoHacker = false;
    public GameObject conversationDisplay;

    public bool[] resistancesArray = new bool[7];

    [HideInInspector]
    public bool matriculaObtenida;
    public bool correctHour;
    public bool correctMinute;

    public int huellas = 0;

    public Button buttonCajon;

    public bool cajaOpen = false;
    public bool candadoOpen= false;

    public GameObject candadoPanel;
    public GameObject cajaOpenPanel;
    public GameObject cajaClosedPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }


    public void HackerChose()
    {
        hacker = true;
    }

    public void chargeFinal()
    {
        if (hacker)
            videoFinalHacker.SetActive(true);

        else
            videoFinalComisario.SetActive(true);

        bombPanel.SetActive(false);
        bombServers.SetActive(false);

    }

    public Sprite GetSprite(string sprite)
    {
        Sprite chosenSprite;

        switch (sprite)
        {
            case "endoscopio":
                chosenSprite = endoscopioSprite;
                usingObject = UsingObject.ENDOSCOPIO;
                break;
            case "llave1":
                chosenSprite = llaveBuenaSprite;
                usingObject = UsingObject.LLAVEBUENA;
                break;
            case "llave2":
                chosenSprite = llaveSprite1;
                usingObject = UsingObject.LLAVEMALA;
                break;
            case "llave3":
                chosenSprite = llaveSprite2;
                usingObject = UsingObject.LLAVEMALA;
                break;
            case "llave4":
                chosenSprite = llaveSprite3;
                usingObject = UsingObject.LLAVEMALA;
                break;
            case "llave5":
                chosenSprite = llaveSprite4;
                usingObject = UsingObject.LLAVEMALA;
                break;
            case "docTaxi":
                chosenSprite = docTaxi;
                usingObject = UsingObject.DOCTAXI;
                MenuController.instance.InstantiateConversation("Si tuviera la matrícula podría llamar, pero sin esa info no podré encontrar a la persona adecuada.");
                break;
            case "matricula":
                chosenSprite = matricula;
                usingObject = UsingObject.MATRICULA;
                break;
            case "pc":
                chosenSprite = PC;
                usingObject = UsingObject.PC;
                break;
            case "foto":
                chosenSprite = foto;
                usingObject = UsingObject.FOTO;
                break;
            default:
                chosenSprite = endoscopioSprite;
                usingObject = UsingObject.NONE;
                break;
        }

        return chosenSprite;
    }

    public UsingObject GetUsingObject()
    {
        return usingObject;
    }

    public void ResetCursor()
    {
        usingObject = UsingObject.NONE;
        MenuController.instance.GetMouseCursor().DestroyCursor();
    }

    public void CargarTaxis()
    {
        switch (currentTaxiSituation)
        {
            case SituacionTaxis.INICIAL:
                EscenaTaxiFueraInicial.SetActive(true);
                EscenaTaxiFueraInicial.transform.GetChild(0).GetComponent<DialogueDisplay>().DisplayConvMenu();

                firstTime = true;
                break;
            case SituacionTaxis.DENTRO:
                EscenaTaxiFueraInicial.SetActive(true);
                break;
            case SituacionTaxis.LLAVECORRECTA:
                EscenaTaxiFueraFinal.SetActive(true);
                DataHolder.instance.conversationDisplay.SetActive(true);
                EscenaTaxiFueraFinal.transform.GetChild(0).GetComponent<DialogueDisplay>().DisplayConvMenu();

                break;
            case SituacionTaxis.FIN:
                EscenaTaxiFueraFinal.SetActive(true);
                DataHolder.instance.conversationDisplay.SetActive(true);

                break;
            default:
                break;
        }
    }

    public void ActivateBombServer()
    {
        bombServers.SetActive(true);
    }

    public void BombsInteraction()
    {
        bombsDesactivated++;
        if (bombsDesactivated >= 3)
        {
            chargeFinal();
        }
    }

    public void OpenArchivador()
    {
        if (!cajaOpen && !candadoOpen)
        {
            candadoPanel.SetActive(true);
        }
        else if (candadoOpen && !cajaOpen)
        {
            cajaClosedPanel.SetActive(true);
        }
        else
        {
            cajaOpenPanel.SetActive(true);
        }
    }

    public void OpenCandado()
    {
        candadoOpen = true;
    }

}
