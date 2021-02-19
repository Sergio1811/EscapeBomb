using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverTitulo : MonoBehaviour
{
    Image image;
    GameObject title;

    private void Start()
    {
        image = GetComponent<Image>();
        if(this.transform.GetChild(0).gameObject!=null)
        title = this.transform.GetChild(0).gameObject;
    }
    public void OnMouseOver()
    {
        if (title != null)
            title.SetActive(true);
    }


    public void OnMouseExit()
    {
        if (title != null)
            title.SetActive(false);
    }
}
