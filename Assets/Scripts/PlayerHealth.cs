using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    public GameObject HealthUI1, HealthUI2, HealthUI3;

    public ParticleSystem collisionParticleSystem;
    AudioSource audioSource;
    public AudioClip healthClip;
    public AudioClip damageClip;

    // Start is called before the first frame update
    void Start()
    {

        //CurrentHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        Weapon weapon = GetComponent<Weapon>();

        if (target.tag == "Health")
        {
            Debug.Log("Health picked up");

           if (CurrentHealth < MaxHealth)
           {
                Destroy(target.gameObject);
                CurrentHealth += 1;
                PlayPartical();
                PlaySound(healthClip);

            }
        }
    }
    public void PlayPartical()
    {
        var em = collisionParticleSystem.emission;
        var dur = collisionParticleSystem.duration;

        em.enabled = true;
        collisionParticleSystem.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BatTrash")
        {
            Debug.Log("Enemy touched");
            CurrentHealth -= 1;
            PlaySound(damageClip);
        }
    }

   void PlayerDeath()
   {
        if (CurrentHealth <= 2)
        {
            HealthUI3.SetActive(false);
        }
        else
        {
            HealthUI3.SetActive(true);
        }

        if (CurrentHealth <= 1)
        {
            HealthUI2.SetActive(false);
        }
        else
        {
            HealthUI2.SetActive(true);
        }

        if (CurrentHealth <= 0)
        {
            HealthUI1.SetActive(false);
        }
        else
        {
            HealthUI1.SetActive(true);
        }


        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene("LossScreen");
            Destroy(gameObject);

        }

   }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
