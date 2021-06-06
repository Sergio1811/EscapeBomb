using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzUltravioleta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tachon"))
        {
            collision.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tachon"))
        {
            collision.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
    }
   
}
