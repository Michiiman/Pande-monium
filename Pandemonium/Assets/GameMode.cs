using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private static GameMode _instance;
    public bool isInfiniteModeActive = false;
    public bool videoIsPlayed = false;
    public bool NarrativeIsSaved = false;
    public static GameMode Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameMode>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameMode).Name);
                    _instance = singletonObject.AddComponent<GameMode>();
                }
            }

            return _instance;
        }
    }
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as GameMode;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void EnableEndlessMode()
    {
        isInfiniteModeActive = true;
    }
    public void DisableEndlessMode()
    {
        isInfiniteModeActive = false;
    }

    public void VideoIsPlayed()
    {
        videoIsPlayed = true;
    }

    public void NarrativeIsPlayed()
    {
        NarrativeIsSaved = true;
    }
}
