using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePapelera : MonoBehaviour
{
    public static PuzzlePapelera instance;
    public GameObject toInactive;

    public int completedPieces = 0;
    public int piecesToComplete;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Update()
    {
        
    }
    public void IsPuzzleCompleted()
    {
        if (piecesToComplete == completedPieces)
        {
            DataHolder.instance.currentObjectsINeed++;
            MenuController.instance.getInventory().addItemToList("Servilleta");
        }
    }

}
