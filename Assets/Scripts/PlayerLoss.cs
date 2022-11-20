using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoss : MonoBehaviour
{
    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {

        if(playerHealth.CurrentHealth == 0)
        {
            SceneManager.LoadScene("LossScreen");
        }
        
    }
}
