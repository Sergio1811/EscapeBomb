﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mobile : MonoBehaviour
{
    public static Mobile instance;

    public GameObject parentPanel;
    public GameObject callPanel;
    public AudioClip callAudio;

    public RectTransform messagesContentRect;
    public GameObject messagePrefab;
    public GameObject not;
    public Button tempButton;
    public void ReceiveCall()
    {
        parentPanel.SetActive(true);
        DataHolder.instance.ui.SetActive(false);
        callPanel.SetActive(true);
        StartCoroutine(PhoneCall());
    }

    private IEnumerator PhoneCall()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = callAudio;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);

        MenuController.instance.InstantiateNotification("Nueva ubicación: Zulo");
        DataHolder.instance.zulo.SetActive(true);
        DataHolder.instance.ui.SetActive(true);
        callPanel.SetActive(false);
        parentPanel.SetActive(false);
    }

    public void ReceiveNotification(int id)
    {
        GameObject newItem = Instantiate(messagePrefab, messagesContentRect.gameObject.transform);

        switch (id)
        {
            case 1:
                newItem.GetComponentInChildren<TextMeshProUGUI>().text = "";
                not.SetActive(true);
                break;
            case 2:
                newItem.GetComponentInChildren<TextMeshProUGUI>().text = "@#95JF@¬6,F";
                Button button = newItem.GetComponent<Button>();
                button.enabled = true;
                not.SetActive(true);
                tempButton = button;
                button.onClick.AddListener(
                    delegate
                    {
                       
                        MenuController.instance.messages.SetActive(true);                        
                    });
                button.onClick.AddListener(NotToRemove);
                
                break;

        }

        messagesContentRect.sizeDelta += new Vector2(0.0f, newItem.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void NotToRemove()
    {
        MenuController.instance.InstantiateNotification("Elige qué responder...");
        tempButton.onClick.RemoveListener(NotToRemove);
    }
}
