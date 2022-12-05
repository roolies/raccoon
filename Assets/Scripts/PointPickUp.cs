using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickUp : MonoBehaviour
{
    public ScoreScript scoreScript;

    public ParticleSystem collisionParticleSystem;

    AudioSource audioSource;
    public AudioClip pointClip;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            PlaySound(pointClip);

        }
    }
    void AddScore()
    {
        scoreScript.ScoreValue += 1;
        scoreScript.score.text = "Score: " + scoreScript.ScoreValue.ToString();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
