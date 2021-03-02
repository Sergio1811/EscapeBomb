using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector]
    public bool[] correctComponets;
    public int howManyComponents;
    public GameObject button;
    public GameObject otherbutton;
    private void Start()
    {
        correctComponets = new bool[howManyComponents];
    }

    public bool CompruebaTodoBool()
    {
        foreach (var item in correctComponets)
        {
            if (item== false)
            {
                return false;
            }
        }
        return true;
    }

    public void BombDeactivated(int ID)
    {
        correctComponets[ID] = true;
        if (CompruebaTodoBool())
        {
            BombaFinalizada();
        }
    }

    public void BombaFinalizada()
    {
        button.SetActive(false);
        otherbutton.SetActive(true);
        this.gameObject.SetActive(false);
        DataHolder.instance.BombsInteraction();
        MenuController.instance.InstantiateNotification("Bomba desactivada.");
    }
}
