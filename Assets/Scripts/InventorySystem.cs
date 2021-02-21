using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Transform parent;

    public GameObject kitVenenoPrefab, bocaPanel;
    public Sprite kitVenenoUsedSprite;
    public Image kitVenenoPanel;
    
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
}
