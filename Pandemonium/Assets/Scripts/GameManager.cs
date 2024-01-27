using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState = GameState.Setup;
    public static GameManager Instance { get; private set; }
    public event Action<GameState> OnStateChanged;
  [SerializeField] private PlayerController player;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("Awake");
    }


    private void SetNewState(GameState SetNewState)
    {
        CurrentState = SetNewState;
        OnStateChanged?.Invoke(CurrentState);
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