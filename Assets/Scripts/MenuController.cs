using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Events;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public GameObject[] scenes;
    public GameObject conversation;
    public GameObject notificationRight;
    public Transform positionConv;
    public Transform positionNot;
    public GameObject MapNotAvailable;
    public Button mapButton;
    public GameObject map;
    public GameObject MapAvailable;

    public Mobile mobile;
    public GameObject mobilePanel;
    public GameObject messages;

    public GameObject inventoryPanel;
    public InventorySystem inventory;
    public MouseCursor mouseCursor;

    public GameObject Correcto1;
    public GameObject Correcto2;
    public GameObject No;

    public GameObject sospechosos;
    public GameObject hacker;
    public GameObject[] buttons;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        DataHolder.instance.buttonLlave1.onClick.AddListener(delegate { printerButton("Llave1"); });
        DataHolder.instance.buttonLlave2.onClick.AddListener(delegate { printerButton("Llave2"); });
        DataHolder.instance.buttonLlave3.onClick.AddListener(delegate { printerButton("Llave3"); });
        DataHolder.instance.buttonLlave4.onClick.AddListener(delegate { printerButton("Llave4"); });
        DataHolder.instance.buttonLlave5.onClick.AddListener(delegate { printerButton("Llave5"); });
        InvokeRepeating("GameStateControl", 1,1);       
    }
    public void DeactivateAllScenes()
    {
        foreach (var item in scenes)
        {
            item.SetActive(false);
        }
    }

    public void InstantiateConversation(string l_TextToDisplay)
    {
        GameObject conv = Instantiate(conversation, positionConv);
        conv.GetComponent<TextAnimation>().dialogues[0] = l_TextToDisplay;
    }


    
    public void InstantiateNotification(string l_notificationToDisplay)
    {
        GameObject conv = Instantiate(notificationRight, positionNot);
        conv.GetComponentInChildren<TextMeshProUGUI>().text = l_notificationToDisplay;
        Destroy(conv,5);
    }

    public void CanMapOpen()
    {
        if (DataHolder.instance.currentObjectsINeed>=DataHolder.instance.howManyObjectsINeed)
        {
            if (scenes[0].activeSelf == true)
                MapAvailable.SetActive(true);

            mapButton.onClick.RemoveAllListeners();

            mapButton.onClick.AddListener(
                delegate {
                    map.SetActive(true);                  
            });
        }
        else
        {
            MapNotAvailable.SetActive(true);
        }
    }

    public IEnumerator PrinterNotificationOn(string llaveName)
    {
        DataHolder.instance.isPrinting = true;
        InstantiateNotification("Impresión iniciada");
        mobile.ReceiveNotification(1);

        switch (llaveName)
        {
            case "Llave1":
                DataHolder.instance.buttonLlave1.interactable = false;
                DataHolder.instance.buttonLlave1.GetComponentInChildren<TextMeshProUGUI>().text = "Imprimiendo...";
                break;
            case "Llave2":
                DataHolder.instance.buttonLlave2.interactable = false;
                DataHolder.instance.buttonLlave2.GetComponentInChildren<TextMeshProUGUI>().text = "Imprimiendo...";
                break; 
            case "Llave3":
                DataHolder.instance.buttonLlave3.interactable = false;
                DataHolder.instance.buttonLlave3.GetComponentInChildren<TextMeshProUGUI>().text = "Imprimiendo...";
                break; 
            case "Llave4":
                DataHolder.instance.buttonLlave4.interactable = false;
                DataHolder.instance.buttonLlave4.GetComponentInChildren<TextMeshProUGUI>().text = "Imprimiendo...";
                break; 
            case "Llave5":
                DataHolder.instance.buttonLlave5.interactable = false;
                DataHolder.instance.buttonLlave5.GetComponentInChildren<TextMeshProUGUI>().text = "Imprimiendo...";
                break;
        }
        //Video ha iniciado la impresión
        yield return new WaitForSeconds(10);
        InstantiateNotification("Impresión acabada");
        mobile.ReceiveNotification(3);

        switch (llaveName)
        {
            case "Llave1":
                DataHolder.instance.buttonLlave1.GetComponentInChildren<TextMeshProUGUI>().text = "Recoger";
                break;
            case "Llave2":
                DataHolder.instance.buttonLlave2.GetComponentInChildren<TextMeshProUGUI>().text = "Recoger";
                break;
            case "Llave3":
                DataHolder.instance.buttonLlave3.GetComponentInChildren<TextMeshProUGUI>().text = "Recoger";
                break;
            case "Llave4":
                DataHolder.instance.buttonLlave4.GetComponentInChildren<TextMeshProUGUI>().text = "Recoger";
                break;
            case "Llave5":
                DataHolder.instance.buttonLlave5.GetComponentInChildren<TextMeshProUGUI>().text = "Recoger";
                break;
        }
        PickKey(llaveName);
        yield return null;
        DataHolder.instance.isPrinting = false;
        //Mensaje ha acabado la impresión
        //Video ha acabado la impresión
    }

    public InventorySystem getInventory()
    {
        return inventory;
    }

    public MouseCursor GetMouseCursor()
    {
        return mouseCursor;
    }

    public void printerButton(string llaveName)
    {
        if (!DataHolder.instance.isPrinting)
        {
            StartCoroutine(PrinterNotificationOn(llaveName));
        }
        else
        {
            InstantiateNotification("Impresión en curso. Por favor espera a que termine....");
        }
    }

    public void PickKey(string llaveName)
    {
        switch (llaveName)
        {
            case "Llave1":
                DataHolder.instance.buttonLlave1.interactable = true;
//#if UNITY_EDITOR
                //UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave1.onClick, 0);
//#end
                DataHolder.instance.buttonLlave1.onClick.RemoveAllListeners();
                print("listener destroyed");
                DataHolder.instance.buttonLlave1.onClick.AddListener(
                    delegate
                    {
                        inventory.addItemToList(llaveName);
                        DataHolder.instance.buttonLlave1.interactable = false;
                        DataHolder.instance.buttonLlave1.GetComponentInChildren<TextMeshProUGUI>().text = "Sin material";

                    });
                break;
            case "Llave2":
                DataHolder.instance.buttonLlave2.interactable = true;
//#if UNITY_EDITOR
               // UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave2.onClick, 0);
//#endif
                DataHolder.instance.buttonLlave2.onClick.RemoveAllListeners();
                DataHolder.instance.buttonLlave2.onClick.AddListener(
                    delegate
                    {
                        inventory.addItemToList(llaveName);
                        DataHolder.instance.buttonLlave2.interactable = false;
                        DataHolder.instance.buttonLlave2.GetComponentInChildren<TextMeshProUGUI>().text = "Sin material";
                    });
                break;
            case "Llave3":
                DataHolder.instance.buttonLlave3.interactable = true;
//#if UNITY_EDITOR
                //UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave3.onClick, 0);
//#endif
                DataHolder.instance.buttonLlave3.onClick.RemoveAllListeners();
                DataHolder.instance.buttonLlave3.onClick.AddListener(
                    delegate
                    {
                        inventory.addItemToList(llaveName);
                        DataHolder.instance.buttonLlave3.interactable = false;
                        DataHolder.instance.buttonLlave3.GetComponentInChildren<TextMeshProUGUI>().text = "Sin material";
                    });
                break;
            case "Llave4":
                DataHolder.instance.buttonLlave4.interactable = true;
//#if UNITY_EDITOR
               // UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave4.onClick, 0);
//#endif
                DataHolder.instance.buttonLlave4.onClick.RemoveAllListeners();
                DataHolder.instance.buttonLlave4.onClick.AddListener(
                    delegate
                    {
                        inventory.addItemToList(llaveName);
                        DataHolder.instance.buttonLlave4.interactable = false;
                        DataHolder.instance.buttonLlave4.GetComponentInChildren<TextMeshProUGUI>().text = "Sin material";
                    });
                break;
            case "Llave5":
                DataHolder.instance.buttonLlave5.interactable = true;
//#if UNITY_EDITOR
                //UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave5.onClick, 0);
  //              #endif
                DataHolder.instance.buttonLlave5.onClick.RemoveAllListeners();
                DataHolder.instance.buttonLlave5.onClick.AddListener(
                    delegate
                    {
                        inventory.addItemToList(llaveName);
                        DataHolder.instance.buttonLlave5.interactable = false;
                        DataHolder.instance.buttonLlave5.GetComponentInChildren<TextMeshProUGUI>().text = "Sin material";
                    });
                break;
            default:
                break;
        }
        

    }

    public void ActivarSatelite()
    {

    }

    public void ActivarCorrecto()
    {
        if (No.activeSelf)
        {
            Correcto2.SetActive(true);
        }
        else Correcto1.SetActive(true);

        DataHolder.instance.guarida.SetActive(true);
        InstantiateNotification("Nueva Ubicación: Guarida del Hacker");
        StartCoroutine(Timer(3));
        DataHolder.instance.ui.SetActive(false);
        messages.SetActive(false);
        mobilePanel.SetActive(false);
        scenes[0].SetActive(false);
        DataHolder.instance.videoSalida.SetActive(true);
    }

    public void DeactivateButton()
    {
        foreach (var item in buttons)
        {
            item.SetActive(false);
        }
    }

    public IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time);
    }

    public void ActivateSospechosos()
    {
        if (!DataHolder.instance.fotoHacker)
            sospechosos.SetActive(true);
        else
            hacker.SetActive(true);
    }

    public void HackerMessage()
    {
        mobile.ReceiveNotification(2);
     
    }

   public void GameStateControl()
    {
        if (!map.activeSelf && !inventoryPanel.activeSelf && !mobilePanel.activeSelf)
        {
            GameManager.instance.ChangeStatePlaying();
        }
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }
   
}


