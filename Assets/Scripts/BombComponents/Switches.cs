using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    public int correctPos;
    public int currentPos;
    public int howManyPos;

    public int ID;
    public Bomb m_Bomb;

    void Start()
    {
        if (currentPos == correctPos)
        {
            m_Bomb.BombDeactivated(ID);
        }
        ChangePos();
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
                    print(hit.collider.gameObject);
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        
                        currentPos++;
                        if (currentPos > howManyPos)
                            currentPos = 1;
                        ChangePos();

                        
                        
                        if (currentPos == correctPos)
                        {
                            m_Bomb.BombDeactivated(ID);
                        }
                        else
                        {
                            m_Bomb.correctComponets[ID] = false;
                        }
                    }
                }
            }
        }
    }

    public void ChangePos()
    {
        if (currentPos==1)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, -20);
        }
        else if (currentPos == 2)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 20);
        }
    }
}
