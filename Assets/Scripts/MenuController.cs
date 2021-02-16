using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public GameObject[] scenes;
    public GameObject conversation;
    public GameObject notificationRight;
    public Transform positionConv;
    public Transform positionNot;

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
}
