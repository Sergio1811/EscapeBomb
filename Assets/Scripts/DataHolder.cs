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

    public GameObject albaran;

    public bool hacker = false;
    public GameObject videoFinalHacker;
    public GameObject videoFinalComisario;
    public GameObject bombPanel;
    public GameObject textBomb;

    [HideInInspector]
    public bool kitUsed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    public void HackerChose()
    {
        hacker = true;
    }

    public void chargeFinal()
    {
        if (hacker)
            videoFinalHacker.SetActive(true);

        else
            videoFinalComisario.SetActive(true);

         bombPanel.SetActive(false);

    }

}
