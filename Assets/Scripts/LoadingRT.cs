using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingRT : MonoBehaviour
{
    public float timeToLoad;
    float currentTimeLoading;
    public Image imageToLoad;
    public float range;
    int currentMoment = 1;
    public GameObject[] panelToUnactive;
    public GameObject folder;
    void Start()
    {
        StartCoroutine(sumandoBarra());
    }

    // Update is called once per frame
    void Update()
    {
       /* currentTimeLoading += Time.deltaTime;
        imageToLoad.fillAmount = currentTimeLoading / timeToLoad;
        if(currentTimeLoading>=timeToLoad)
        {
            //do things
            print("dothings");
        }*/
    }

    public IEnumerator sumandoBarra()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,2));
        imageToLoad.fillAmount = range * currentMoment;
        currentMoment++;

        if(imageToLoad.fillAmount<1)
        StartCoroutine(sumandoBarra());
        else
        {
            foreach (var item in panelToUnactive)
            {
                item.SetActive(false);
                
            }
            folder.SetActive(true);
        }
    }
}
