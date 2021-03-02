using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Image image;
    public void OnMouseOver()
    {
        if (GameManager.instance.currentGameState==GameManager.GameState.PLAYING)
        {
            image.color = new Color32(255, 255, 255, 255);
        }    
    }

    public void OnMouseExit()
    {
        image.color = new Color32(0, 0, 0, 0);
    }
}
