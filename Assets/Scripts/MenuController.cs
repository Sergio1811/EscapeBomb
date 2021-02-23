using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public InventorySystem inventory;
    public MouseCursor mouseCursor;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
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
        MenuController.instance.InstantiateNotification("Impresión iniciada");

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
        MenuController.instance.InstantiateNotification("Impresión acabada");
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
        StartCoroutine(PrinterNotificationOn(llaveName));
    }

    public void PickKey(string llaveName)
    {
        switch (llaveName)
        {
            case "Llave1":
                DataHolder.instance.buttonLlave1.interactable = true;
                UnityEditor.Events.UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave1.onClick, 0);
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
                UnityEditor.Events.UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave2.onClick, 0);
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
                UnityEditor.Events.UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave3.onClick, 0);
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
                UnityEditor.Events.UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave4.onClick, 0);
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
                UnityEditor.Events.UnityEventTools.RemovePersistentListener(DataHolder.instance.buttonLlave5.onClick, 0);
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
}
