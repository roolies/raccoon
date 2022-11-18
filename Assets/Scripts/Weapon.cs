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
	public GameObject bullet;
	public Ammo ammo;

	void Start()
	{

	}

	void Update()
	{


		


	}

	public void Shoot(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			if(ammo.CurrentAmmo >= 0)
            {
				StartCoroutine(Shoot());

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

		isShooting = true;
		GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
		newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
		newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);

		Debug.Log("Shoot");
		yield return new WaitForSeconds(shootTimer);
		isShooting = false;
    }




	
}
