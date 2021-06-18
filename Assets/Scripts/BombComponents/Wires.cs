using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    public GameObject[] wires;
    GameObject currentWire;
    public int ID;
    public Bomb m_Bomb;

    void Start()
    {

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
                    if (hit.collider.CompareTag("0") || hit.collider.CompareTag("1") || hit.collider.CompareTag("2") || hit.collider.CompareTag("3"))
                    {
                        if (currentWire != null)
                        {
                            if (hit.collider.CompareTag(currentWire.tag))
                            {
                                if (hit.collider.gameObject != currentWire)
                                {
                                    wires[int.Parse(currentWire.tag)].SetActive(true);
                                    CheckAllWires();
                                    currentWire = null;
                                }
                            }
                            else { currentWire = null; }
                        }
                        else
                            currentWire = hit.collider.gameObject;
                    }
                }
            }
        }
    }

    void CheckAllWires()
    {
        foreach (var item in wires)
        {
            if (item.activeSelf != true)
            {
                return;
            }
        }
        m_Bomb.BombDeactivated(ID);
    }
}
