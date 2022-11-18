using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float MaxAmmo;
    public float CurrentAmmo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "AmmoPickUp")
        {
            Debug.Log("Health picked up");

            // if (CurrentHealth < MaxHealth)
            // {
            Destroy(target.gameObject);
             CurrentAmmo += 1;
            // }
        }
    }
}
