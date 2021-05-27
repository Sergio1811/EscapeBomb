using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField]
    private GameObject parentPanel;

    public GameObject playButton, pauseButton;
    public RectTransform currentSecObjectRectTransform;

    public AudioClip audioWhatsapp;
    private AudioSource audioSource;

    private float wait;
    private bool check, isPlaying;

    public RectTransform initPos, finalPos;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = audioWhatsapp;
        audioSource.pitch = 1f;
        currentSecObjectRectTransform.localPosition = initPos.localPosition;
        wait = audioWhatsapp.length;
        check = true;
    }

    void Update()
    {
        if (check && isPlaying)
        {
            wait -= Time.deltaTime;
            currentSecObjectRectTransform.localPosition = Vector3.MoveTowards(currentSecObjectRectTransform.localPosition,
                finalPos.localPosition,
                1f/9.5f);
        }

        if (wait < 0.0f)
        {
            check = false;
            FinishAudio();
        }
    }

    public void PlayAudio()
    {
        audioSource.Play();
        isPlaying = true;
    }

    public void StopAudio()
    {
        audioSource.Pause();
        isPlaying = false;
    }

    private void FinishAudio()
    {
        audioSource.Stop();
        isPlaying = false;
        currentSecObjectRectTransform.localPosition = initPos.localPosition;
        wait = audioWhatsapp.length;
        parentPanel.SetActive(false);
    }
}
