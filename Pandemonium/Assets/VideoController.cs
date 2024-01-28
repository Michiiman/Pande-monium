using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoController;
    [SerializeField] private AudioSource MenuClip;
    [SerializeField] private GameObject MenuCanvas;
    
    
    
    private void Start()
    {
        if (!GameMode.Instance.videoIsPlayed)
        {
            videoController.Play();
            MenuCanvas.SetActive(false);
            StartCoroutine(VideoEnds());
        }
        else
        {
            MenuSetup();
        }
    }

    private IEnumerator VideoEnds()
    {
        yield return new WaitForSeconds((float)videoController.clip.length+ 2f);
        MenuSetup();
        GameMode.Instance.VideoIsPlayed();
    }

    private void MenuSetup()
    {
        videoController.gameObject.SetActive(false);
        MenuClip.Play();
        MenuCanvas.SetActive(true);
    }
}