using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Linterna : MonoBehaviour, IDragHandler
{
    Canvas myCanvas;

    // Start is called before the first frame update
    void Start()
    {
        myCanvas = GetComponentInParent<Canvas>();

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);
    }
}
