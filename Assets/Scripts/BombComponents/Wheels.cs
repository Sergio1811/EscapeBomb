﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public int correctPos;
    public int currentPos = 1;
    int rotationValue;
    public int posNumber;

    public int ID;
    public Bomb m_Bomb;

    void Start()
    {
        rotationValue = 360 / posNumber;
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, currentPos * rotationValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RectTransform invPanel = transform as RectTransform;

            if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        currentPos++;
                        if (currentPos>posNumber)
                        {
                            currentPos = 1;
                        }

                        if (currentPos==correctPos)
                        {
                            m_Bomb.BombDeactivated(ID);
                        }
                        else
                        {
                            m_Bomb.correctComponets[ID] = false;
                        }

                        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, currentPos * rotationValue);

                    }
                }
            }
        }
    }
}
