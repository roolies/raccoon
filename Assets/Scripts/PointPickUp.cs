using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickUp : MonoBehaviour
{
    public ScoreScript scoreScript;

    public ParticleSystem collisionParticleSystem;
    


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ScorePickup")
        {
            Debug.Log("Score picked up");
            AddScore();
            Destroy(target.gameObject);
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

        }
    }
    void AddScore()
    {
        scoreScript.ScoreValue += 1;
        scoreScript.score.text = "Score: " + scoreScript.ScoreValue.ToString();
    }
}
