using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingRT : MonoBehaviour
{
    public float timeToLoad;
    float currentTimeLoading;
    public Image imageToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLoading += Time.deltaTime;
        imageToLoad.fillAmount = currentTimeLoading / timeToLoad;
        if(currentTimeLoading>=timeToLoad)
        {
            //do things
            print("dothings");
        }
    }
}
