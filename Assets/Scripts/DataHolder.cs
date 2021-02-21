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
    public GameObject heladeria;
    public GameObject farmacia;
    public GameObject fruteria;
    public GameObject chipa;
    public GameObject libreria;
    public GameObject recepcion;
    public GameObject videojuegos;
    public GameObject peluqueria;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

   
   
}
