using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    public GameObject ui;
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
    public GameObject taxistaSeVa;

    public Button buttonLlave1;
    public Button buttonLlave2;
    public Button buttonLlave3;
    public Button buttonLlave4;
    public Button buttonLlave5;

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
