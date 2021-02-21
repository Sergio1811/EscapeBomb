using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFinish : MonoBehaviour
{
     double time;
     double currentTime;
    public VideoPlayer vp;
    public GameObject[] cosasAActivar;
    // Use this for initialization
    void Start()
    {
        time = vp.clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = vp.time;
        if (currentTime >= time)
        {
            this.gameObject.SetActive(false);
            foreach (var item in cosasAActivar)
            {
                item.SetActive(true);
            }
        }
    }
    
}
