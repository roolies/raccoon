using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public ScoreScript scoreScript;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy touched");
            AddScore();


        }


    }

    void AddScore()
    {
        scoreScript.ScoreValue += 1;
        scoreScript.score.text = "Score: " + scoreScript.ScoreValue.ToString();
    }

}
