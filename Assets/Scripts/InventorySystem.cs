﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Transform parent;
    public GameObject zoomParent;

    public GameObject kitVenenoPrefab, bocaPanel;
    public Sprite kitVenenoUsedSprite;
    public Image kitVenenoPanel;

    public GameObject[] items;
    public Transform[] itemListPositions;
    public bool[] itemListAvailable;

    public void checkUsedItems()
    {
        if (DataHolder.instance.kitUsed)
        {
            kitVenenoPanel.sprite = kitVenenoUsedSprite;
        }
    }

    public void instantiateItem(string item)
    {
        switch (item)
        {
            case "kitVeneno":
                if (bocaPanel.activeSelf && !DataHolder.instance.kitUsed) {
                    Instantiate(kitVenenoPrefab, parent);
                    this.transform.parent.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void addItemToList(string itemName)
    {
        foreach (var item in items)
        {
            if (itemName.Equals(item.name))
            {
                for (int i = 0; i < itemListAvailable.Length; i++)
                {
                    if (!itemListAvailable[i])
                    {
                        item.transform.localPosition = itemListPositions[i].localPosition;
                        item.GetComponent<Image>().enabled = true;
                        item.GetComponent<Button>().enabled = true;
                        item.GetComponent<Button>().onClick.AddListener(delegate { zoomItem(item.name); });
                        itemListAvailable[i] = false;
                        return;
                    }
                }
            }
        }
    }

    public void zoomItem(string itemName)
    {
        foreach (var item in items)
        {
            if (itemName.Equals(item.name))
            {
                zoomParent.SetActive(true);
                zoomParent.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
                return;
            }
        }
    }
}
