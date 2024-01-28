using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneButton : MonoBehaviour
{
    public void ButtonClickHistory()
    {
        GameMode.Instance.DisableEndlessMode();
        SceneManager.LoadScene("SampleScene");
    }

    public void ButtonClickEndlessMode()
    {
        GameMode.Instance.EnableEndlessMode();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
