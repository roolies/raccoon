using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    
    private float TimeLeft = 1.5f;
    public bool TimerOn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timmer();
    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
               
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                Destroy(gameObject);

            }

        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        //TimerUI.text = "invincibility Frames: " + string.Format("{0:0}", seconds);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy touched");
            Destroy(collision.gameObject);
            

        }

        if (collision.gameObject.tag == "Ground")
        {
            TimerOn = true;
            Debug.Log("Ground touched");
            

        }


    }


}
