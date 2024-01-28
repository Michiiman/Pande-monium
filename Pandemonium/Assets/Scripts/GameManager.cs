using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState = GameState.Setup;
    public static GameManager Instance { get; private set; }
    public event Action<GameState> OnStateChanged;
    public PlayerController player;
    public TMPro.TMP_Text textoTiempo;
    public float tiempoTotalSegundos = 100f;
    private bool isGameplay = false;
    public GameObject PanelNarrativo;
    public AudioSource GameplayMusic;
  
    private IEnumerator UpdateTime()
    {
      
        float tiempoRestante = tiempoTotalSegundos;

        while (tiempoRestante > 0f)
        {
            if (isGameplay)
            {
                textoTiempo.gameObject.SetActive(true);
                int minutos = Mathf.FloorToInt(tiempoRestante / 60);
                int segundos = Mathf.FloorToInt(tiempoRestante % 60);

                textoTiempo.text = "Tiempo: " + minutos.ToString("00") + ":" + segundos.ToString("00");

                yield return new WaitForSeconds(1f);

                tiempoRestante -= 1f;
            }
            else
            {
                yield return null;
            }
        }

        textoTiempo.text = "¡Tiempo Fuera!";
        SetNewState(GameState.Win);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("Awake");
    }

    private void Start()
    {
        if (!GameMode.Instance.isInfiniteModeActive) StartCoroutine(UpdateTime());
        SetNewState(GameState.Setup);
        if (!GameMode.Instance.isInfiniteModeActive)
        {
            if (!GameMode.Instance.NarrativeIsSaved)
            {
                StartCoroutine(SetupGameplay());
            }
            else
            {
                PanelNarrativo.SetActive(false);
                SetNewState(GameState.Gameplay);
            }
            
            
        }
        else
        {
            PanelNarrativo.SetActive(false);
            SetNewState(GameState.Gameplay);
        }
    }

    private IEnumerator SetupGameplay()
    {
        yield return new WaitForSeconds(6f);
        PanelNarrativo.SetActive(false);
        SetNewState(GameState.Gameplay);
        GameMode.Instance.NarrativeIsPlayed();
        
    }

    private void SetNewState(GameState SetNewState)
    {
        CurrentState = SetNewState;
        OnStateChanged?.Invoke(CurrentState);
        isGameplay = CurrentState == GameState.Gameplay;
        if(CurrentState == GameState.Win || CurrentState == GameState.Lose) GameplayMusic.Pause();
    }

    public void PauseGame()
    {
        SetNewState(GameState.Pause);
    }

    public void ResumeGame()
    {
        SetNewState(GameState.Gameplay);
    }

    public void LoseGame()
    {
        SetNewState(GameState.Lose);
    }
    
}


public enum GameState
{
    Setup,
    Gameplay,
    Pause,
    Win,
    Lose
}