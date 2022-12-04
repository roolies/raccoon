using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalTrigger : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;

       
    public void OntriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);

        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
