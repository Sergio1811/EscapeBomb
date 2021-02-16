using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public int currentPos;
    public int correctPos;
    public int howManyPos;

    public Bomb m_Bomb;
    public int ID;
    void Start()
    {
        this.transform.position = new Vector3(currentPos * 0.5f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
                        if (Input.GetAxis("Mouse X") < 0)
                        {
                            //Code for action on mouse moving left
                            print("Mouse moved left");
                            if(currentPos>1)
                            currentPos--;
                        }
                        if (Input.GetAxis("Mouse X") > 0)
                        {
                            //Code for action on mouse moving right
                            print("Mouse moved right");
                            if(currentPos<howManyPos)
                            currentPos++;
                        }
                        if (currentPos == correctPos)
                        {
                            m_Bomb.BombDeactivated(ID);
                        }
                        else
                        {
                            m_Bomb.correctComponets[ID] = false;
                        }
                        this.transform.position = new Vector3(currentPos * 0.5f, 0, 0);

                    }
                }
            }
        }
    }
}
