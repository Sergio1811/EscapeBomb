using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Buttons : MonoBehaviour
{
    [Tooltip("1 - Rojo   2 - Azul   3 - Marron")]
    public int[] correctOrder;
    int[] currentOrder;

    public int ID;
    public Bomb m_Bomb;

    int currentLength;
    public AudioSource error;
    private void Start()
    {
        currentOrder = new int[correctOrder.Length];
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
                    if (hit.collider.CompareTag("Rojo"))
                    {
                        currentOrder[currentLength] = 1;

                        CorrectButton();
                        hit.collider.gameObject.GetComponent<Animation>().Play();
                    }

                    if (hit.collider.CompareTag("Azul"))
                    {
                        currentOrder[currentLength] = 2;

                        CorrectButton();
                        hit.collider.gameObject.GetComponent<Animation>().Play();

                    }

                    if (hit.collider.CompareTag("Marron"))
                    {
                        currentOrder[currentLength] = 3;

                        CorrectButton();
                        hit.collider.gameObject.GetComponent<Animation>().Play();

                    }


                }
            }
        }
    }

    public void CorrectButton()
    {
        if (currentOrder[currentLength] == correctOrder[currentLength])
        {
            currentLength++;
            if (currentLength == correctOrder.Length)
                DetectFinalCombo();
        }
        else
        {
            MenuController.instance.InstantiateNotification("Botón incorrecto");
            error.Play();
            for (int i = 0; i < currentOrder.Length; i++)
            {
                currentOrder[i] = 0;
            }
            currentLength = 0;
        }
    }

    public void DetectFinalCombo()
    {
        print("entro");
        if (correctOrder.SequenceEqual(currentOrder))
        {
            print("combo completo");
            m_Bomb.BombDeactivated(ID);
        }
    }
}
