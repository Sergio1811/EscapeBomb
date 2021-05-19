using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffGame : MonoBehaviour
{
    int currentNum;
    GameObject temp;
    int currentSolved;
    public GameObject dialogue;
    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Launching from current camera
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Diff"))
                {
                    if (currentNum == 0)
                    {
                        currentNum = int.Parse(hit.transform.gameObject.name);
                        temp = hit.transform.gameObject;
                    }
                    else if (currentNum.ToString() == hit.transform.gameObject.name && hit.transform.gameObject != temp)
                    {
                        hit.transform.GetChild(0).gameObject.SetActive(true);
                        temp.transform.GetChild(0).gameObject.SetActive(true);
                        currentNum = 0;
                        temp = null;
                        currentSolved++;
                        if (currentSolved>=6)
                        {
                            dialogue.SetActive(true);
                        }
                    }
                    else
                    {
                        currentNum = 0;
                        temp = null;
                    }
                }
            }
        }
    }
}
