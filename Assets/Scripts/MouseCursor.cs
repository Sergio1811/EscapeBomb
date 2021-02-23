﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Image currentRend;

    void Start()
    {
        currentRend = GetComponent<Image>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0) && DataHolder.instance.GetUsingObject() != DataHolder.UsingObject.NONE)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Cajon"))
                {
                    if (DataHolder.instance.GetUsingObject() == DataHolder.UsingObject.ENDOSCOPIO)
                    {
                        MenuController.instance.InstantiateConversation("Vale, me apunto en mi libreta el perfil de la cerradura.");
                        MenuController.instance.getInventory().addItemToList("LlaveLibreta");
                    }
                    else if (DataHolder.instance.GetUsingObject() == DataHolder.UsingObject.LLAVEMALA)
                    {
                        MenuController.instance.InstantiateConversation("Vaya parece que no es la correcta.");
                    }
                    else if (DataHolder.instance.GetUsingObject() == DataHolder.UsingObject.LLAVEBUENA)
                    {
                        MenuController.instance.InstantiateConversation("Se han conseguido unos documentos.");
                        MenuController.instance.getInventory().addItemToList("DocTaxi");
                    }
                }
            }

            DataHolder.instance.ResetCursor();
        }
    }

    public void SetCustomCursor(string cursor)
    {
        currentRend.sprite = DataHolder.instance.GetSprite(cursor);

        Color newColor = new Color(255, 255, 255, 255);
        currentRend.color = newColor;
    }

    public void DestroyCursor()
    {
        Color newColor = new Color(255, 255, 255, 0);
        currentRend.color = newColor;
    }
}
