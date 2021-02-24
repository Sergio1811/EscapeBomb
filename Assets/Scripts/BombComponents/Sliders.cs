using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public int correctPos;
    public int currentPos;
    public int howManyPos;

    Vector3 startPos;
    public int ID;
    public Bomb m_Bomb;
    public bool right;

    void Start()
    {
        if (currentPos == correctPos)
        {
            m_Bomb.BombDeactivated(ID);
        }
        startPos = this.transform.localPosition;
        this.transform.localPosition = new Vector3(startPos.x - ((currentPos - 1) * 0.065f), startPos.y, startPos.z);
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
                        if (currentPos==howManyPos && right)
                        {
                            right = !right;
                        }
                        else if (currentPos==1 && !right)
                        {
                            right = true;
                        }

                        if (right)
                            currentPos++;

                        else
                            currentPos--;

                        if (currentPos == correctPos)
                        {
                            m_Bomb.BombDeactivated(ID);
                        }
                        else
                        {
                            m_Bomb.correctComponets[ID] = false;
                        }
                        this.transform.localPosition = new Vector3(startPos.x - ((currentPos - 1) * 0.065f), startPos.y, startPos.z);
                    }
                }
            }
        }
    }
}
