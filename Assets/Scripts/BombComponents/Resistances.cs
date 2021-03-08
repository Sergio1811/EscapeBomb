using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistances : MonoBehaviour
{
    public string correctPos;
    bool m_PieceClicked;
    bool dentro;
    GameObject colision;
    private Vector3 m_ClickedPiecePosition;
    private Vector3 m_startPos;


    public int ID;
    public Bomb m_Bomb;

    void Start()
    {
        m_ClickedPiecePosition = this.transform.position;
        m_startPos = m_ClickedPiecePosition;
    }

    void Update()
    {
        if (!m_PieceClicked)
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
                            m_PieceClicked = true;
                        }
                    }
                }
            }

        }

        if (m_PieceClicked)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPosition.z = m_ClickedPiecePosition.z;

                this.transform.position = touchPosition;
            }

        }

        if (m_PieceClicked && Input.GetMouseButtonUp(0))
        {

            if (dentro)
            {
                this.transform.position = colision.gameObject.transform.position;

                m_PieceClicked = false;
                
            }
            else
            {
                m_PieceClicked = false;
                this.transform.position = m_ClickedPiecePosition;
            }
            DetectCorrect();

        }
    }

    private void OnTriggerEnter(Collider _collision)
    {

        if (_collision.gameObject.CompareTag("Resistencia"))
        {
            colision = _collision.gameObject;

            print(int.Parse(colision.gameObject.name));
            if (DataHolder.instance.resistancesArray[int.Parse(colision.gameObject.name) - 1] == false)
            {
                DataHolder.instance.resistancesArray[int.Parse(colision.gameObject.name) - 1] = true;

                dentro = true;
            }
            else
            {
                colision = null;
            }
        }

    }

    private void OnTriggerExit(Collider _collision)
    {

        if (colision != null)
        {
            DataHolder.instance.resistancesArray[int.Parse(colision.gameObject.name) - 1] = false;
            dentro = false;
        }


        if (dentro)
        {
            dentro = false;
            colision = null;

        }
    }

    public void DetectCorrect()
    {
        if (this.gameObject.tag == correctPos)
        {
            m_Bomb.BombDeactivated(ID);
        }
    }
}
