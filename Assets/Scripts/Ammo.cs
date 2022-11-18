using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    public float MaxAmmo;
    public float CurrentAmmo;

    public TextMeshProUGUI AmmoUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoUI.text = "X " + CurrentAmmo.ToString();
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
