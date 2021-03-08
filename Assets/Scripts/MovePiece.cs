using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePiece : MonoBehaviour
{

    public bool m_PieceLocked = false;
    bool m_PieceClicked = false;
    private Vector3 m_ClickedPiecePosition;
    public bool canMove = false;
    private bool dentro = false;
    private GameObject colision;


    public bool thispiece = false;
    private Vector3 startPos = Vector3.zero;

    private void Start()
    {
        startPos = gameObject.transform.position;
        m_ClickedPiecePosition = startPos;

    }
    void Update()
    {

        if (!m_PieceLocked && !m_PieceClicked)
        {


            if (Input.GetMouseButtonDown(0))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPosition.z = 0f;

                RaycastHit2D l_RaycastHit = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
                if (l_RaycastHit)
                {
                    if (l_RaycastHit.collider.gameObject == this.gameObject)
                    {
                        m_PieceClicked = true;

                    }
                }
            }



        }

        if (m_PieceClicked)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPosition.z = 0f;

                this.transform.position = touchPosition;
            }

        }



        if (m_PieceClicked && Input.GetMouseButtonUp(0))
        {


            if (dentro)
            {
                this.transform.position = colision.gameObject.transform.position;
                PuzzlePapelera.instance.completedPieces++;
                PuzzlePapelera.instance.IsPuzzleCompleted();
                m_PieceLocked = true;
                m_PieceClicked = false;
                colision = null;
            }
            else
            {
                m_PieceClicked = false;
                this.transform.position = m_ClickedPiecePosition;
            }

        }


    }

    IEnumerator WaitToFrame()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.gameObject.name == this.gameObject.name)
        {
            colision = _collision.gameObject;
            dentro = true;
        }

    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.gameObject.name == this.gameObject.name)
        {
            dentro = false;
        }

    }
}
