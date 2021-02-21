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

    public IEnumerator PrinterNotificationOn()
    {
        //Mensaje ha iniciado la impresión
        //Video ha iniciado la impresión
        yield return new WaitForSeconds(180);
        //Mensaje ha acabado la impresión
        //Video ha acabado la impresión
    }

    public InventorySystem getInventory()
    {
        return inventory;
    }
}
