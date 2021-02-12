using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class KitVeneno : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Canvas myCanvas;
    Vector3 startPos;
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            print("holaa?");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Boca"))
                {
                    Debug.Log("true");
                }
            }
            else
                transform.localPosition = startPos;
        }
    }
    
}
