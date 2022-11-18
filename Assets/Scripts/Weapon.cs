using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
	public float shootSpeed, shootTimer;
	//public float Ammo;

	public bool isShooting;

	public Transform shootPos;
	public GameObject Can,Bannana,Apple;
	public Ammo ammo;

	public float CanNumber;

	void Start()
	{
		CanNumber = 1;
	}

	void Update()
	{

		if(CanNumber > 3)
        {
			CanNumber = 1;
        }
		


	}

	public void Shoot(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			if(ammo.CurrentAmmo > 0)
            {
				StartCoroutine(Shoot());
				CanNumber += 1;
			}

			

		}

		if (context.canceled)
		{
			
		}
	}

	IEnumerator Shoot()
    {
		int direction()
        {
			if(transform.localScale.x < 0f)
            {
				return -1;
            }
            else
            {
				return +1;
            }
        }

		

		if(CanNumber == 1)
        {
			GameObject NewCan = Instantiate(Can, shootPos.position, Quaternion.identity);
			NewCan.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
			NewCan.transform.localScale = new Vector2(NewCan.transform.localScale.x * direction(), NewCan.transform.localScale.y);
        }

        if (CanNumber == 2)
        {
			GameObject NewBannana = Instantiate(Bannana, shootPos.position, Quaternion.identity);
			NewBannana.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
			NewBannana.transform.localScale = new Vector2(NewBannana.transform.localScale.x * direction(), NewBannana.transform.localScale.y);
        }

		if(CanNumber == 3)
        {
			GameObject NewApple = Instantiate(Apple, shootPos.position, Quaternion.identity);
			NewApple.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
			NewApple.transform.localScale = new Vector2(NewApple.transform.localScale.x * direction(), NewApple.transform.localScale.y);
        }




		ammo.CurrentAmmo -= 1;
		Debug.Log("Shoot");
		yield return new WaitForSeconds(shootTimer);
		isShooting = false;
    }




	
}
