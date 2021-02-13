using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] scenes;
    public void DeactivateAllScenes()
    {
        foreach (var item in scenes)
        {
            item.SetActive(false);
        }
    }
}
