using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject winPanel;
    public GameObject LosePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.CurrentState == GameState.Gameplay)
        {
            PanelMenu.SetActive(true);
            GameManager.Instance.PauseGame();
        }

        winPanel.SetActive(GameManager.Instance.CurrentState == GameState.Win);
        LosePanel.SetActive(GameManager.Instance.CurrentState == GameState.Lose);
    }

    public void ResumeGame()
    {
        PanelMenu.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    public void LoadGameMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}