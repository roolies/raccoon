using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public ScoreScript scoreScript;

    public ParticleSystem collisionParticleSystem;

    //public GameObject Sprite;

    public float TimeLeft;
    public bool TimerOn;


    void Start()
    {
        TimeLeft = 0.5f;

    }

    void Update()
    {
        Timmer();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy touched");
            AddScore();
            PlayPartical();
            //Destroy(Sprite);
            TimerOn = true;
        }


    }

    void Timmer()
    {

        if (TimerOn)
        {

            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                
            }
            else
            {
                Debug.Log("Time is Up");
                TimerOn = false;
                Destroy(gameObject);

            }

        }
    }

    void AddScore()
    {
        scoreScript.ScoreValue += 1;
        scoreScript.score.text = "Score: " + scoreScript.ScoreValue.ToString();
    }

    public void PlayPartical()
    {
        var em = collisionParticleSystem.emission;
        var dur = collisionParticleSystem.duration;

        em.enabled = true;
        collisionParticleSystem.Play();
    }

}
