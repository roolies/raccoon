using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{
    public PauseScript pauseScript;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pauseScript.gamePaused = false;
    }
}
