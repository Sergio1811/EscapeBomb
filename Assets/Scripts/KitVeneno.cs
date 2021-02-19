﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class KitVeneno : MonoBehaviour, IDragHandler, IEndDragHandler
{

    Canvas myCanvas;
    Vector3 startPos;
    public float timeToMeasure;
    float currentTimeMeasuring;
    public Slider sliderTemp;
    bool measured;
    private void Start()
    {
        myCanvas = GetComponentInParent<Canvas>();
        startPos = this.transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);

        RectTransform invPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            print("holaa?");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Boca"))
                {
                    if (!sliderTemp.gameObject.activeSelf)
                        sliderTemp.gameObject.SetActive(true);

                    if (!measured)
                    {
                        currentTimeMeasuring += Time.deltaTime;
                        sliderTemp.value = currentTimeMeasuring / timeToMeasure;

                        if (currentTimeMeasuring >= timeToMeasure)//If finalized call function
                        {
                            Debug.Log("true");
                            Destroy(this.gameObject);
                            //cambiar item en inventario
                            DataHolder.instance.currentObjectsINeed++;
                            StartCoroutine(Timer(300));
                        }
                    }
                }
            }

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!measured)
        {
            transform.localPosition = startPos;
            currentTimeMeasuring = 0;
            sliderTemp.value = 0;

        }
    }

    public IEnumerator Timer(float l_Timer)
    {
        yield return new WaitForSeconds(l_Timer);
        print("ale 5 minutos");
    }

}
