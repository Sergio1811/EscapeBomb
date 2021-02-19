using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    public int howManyObjectsINeed;
    public int currentObjectsINeed = 1;

    public GameObject guarida;
    public GameObject merceria;
    public GameObject zulo;
    public GameObject salaServidor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

   
   
}
