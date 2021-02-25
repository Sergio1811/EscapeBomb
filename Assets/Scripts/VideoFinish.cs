using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFinish : MonoBehaviour
{

    public VideoPlayer vp;
    public GameObject[] cosasAActivar;
    public string myFileName;
    // Use this for initialization

    bool firstFrame = false;
    void Start()
    {
        DataHolder.instance.conversationDisplay.SetActive(false);
        DataHolder.instance.ui.SetActive(false);
        vp.url = Application.streamingAssetsPath + "/" + myFileName;
        vp.Prepare();
        vp.Play();
    }


    // Update is called once per frame
    void Update()
    {

        if (vp.isPrepared)
        {
            firstFrame = true;
        }

        if (firstFrame)
        {
            if (!vp.isPlaying)
            {
                this.gameObject.SetActive(false);
                foreach (var item in cosasAActivar)
                {
                    DataHolder.instance.ui.SetActive(true);
                    DataHolder.instance.conversationDisplay.SetActive(true);
                    item.SetActive(true);
                }
            }
        }

    }

}
