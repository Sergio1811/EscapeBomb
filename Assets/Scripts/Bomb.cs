using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector]
    public bool[] correctComponets;
    public int howManyComponents;
    public GameObject[] buttonsToDeactivate;
    public GameObject[] buttonsToActivate;
    public GameObject[] buttonsToDestroy;
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
        foreach (var item in buttonsToDeactivate)
        {
            if (item != null)
                item.SetActive(false);
        }
        foreach (var item in buttonsToDestroy)
        {
            if (item != null)
                Destroy(item);
        }
        foreach (var item in buttonsToActivate)
        {
            if(item!=null)
            item.SetActive(true);
        }
        this.gameObject.SetActive(false);
        DataHolder.instance.BombsInteraction();
        MenuController.instance.InstantiateNotification("Bomba desactivada.");
    }
}
