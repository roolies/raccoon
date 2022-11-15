using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
        //CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //CurrentHealth = MaxHealth;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Health")
        {
            Debug.Log("Health picked up");

           // if (CurrentHealth < MaxHealth)
           // {
                   Destroy(target.gameObject);
                   CurrentHealth += 1;
           // }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy touched");
            CurrentHealth -= 1;
        }
    }

   void PlayerDeath()
   {
        if(CurrentHealth == 0)
        {
            Destroy(gameObject);

        }


    }

}
