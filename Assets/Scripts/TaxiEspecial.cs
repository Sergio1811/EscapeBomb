using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiEspecial : MonoBehaviour
{
    public Button boton;
     void Update()
    {
        if (DataHolder.instance.correctMinute && DataHolder.instance.correctHour)
        {
            boton.interactable = true;
        }   
    }
}
