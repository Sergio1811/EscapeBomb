using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    public GameObject parentPanel;
    public GameObject callPanel;
    public AudioClip callAudio;

    public RectTransform messagesContentRect;
    public GameObject messagePrefab;

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
        switch (id)
        {
            case 1:
                GameObject newItem = Instantiate(messagePrefab, messagesContentRect.gameObject.transform);
                newItem.GetComponentInChildren<TextMeshProUGUI>().text = "";
                break;
        }

        messagesContentRect.sizeDelta += new Vector2(0.0f, 170.0f);
    }
}
