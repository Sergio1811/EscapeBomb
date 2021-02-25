using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUbi : MonoBehaviour
{
    public string textNot;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(UbiMessage);
    }

     void UbiMessage()
    {
        MenuController.instance.InstantiateNotification(textNot);
        this.GetComponent<Button>().onClick.RemoveListener(UbiMessage);

    }


}
