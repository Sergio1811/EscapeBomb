using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Endoscopio : MonoBehaviour, IDragHandler, IEndDragHandler
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
                print(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Cajon"))
                {                    
                      Debug.Log("true");
                      Destroy(this.gameObject);
                      //cambiar item en inventario
                    
                }
            }

        }
        else
        transform.localPosition = startPos;
           
        
    }

    public IEnumerator Timer(float l_Timer)
    {
        yield return new WaitForSeconds(l_Timer);
        print("ale 5 minutos");
    }

}
