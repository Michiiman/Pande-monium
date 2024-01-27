using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneButton : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
