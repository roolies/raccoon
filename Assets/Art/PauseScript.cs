using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseScript : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseCanvas;
    public GameObject gameCanvas;
    
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }


    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gamePaused = !gamePaused;
            if (gamePaused == true)
            {
                Time.timeScale = 0;
                pauseCanvas.gameObject.SetActive(true);
                gameCanvas.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                pauseCanvas.gameObject.SetActive(false);
                gameCanvas.gameObject.SetActive(true);
            }



        }

    }

    void Update()
    {
 

           

       
    }
}
