using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatMovement : MonoBehaviour
{
    public float flySpeed = 0.5f;     
    public float stopDistance = 0.5f;  
    public float maxVelocity = 1.5f;    
    public Vector2[] patrolPoints;
    
    private int currentPoint = 0;
    System.Random rnd = new System.Random();
    private Rigidbody2D batRB;

    private bool canThrowTrash = true;
    [SerializeField] public Transform shootPosition;

    private int num;

    [SerializeField] public GameObject Can;
    [SerializeField] public GameObject BananaPeel;
    [SerializeField] public GameObject AppleCore;

    void Awake()
    {
        batRB = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        if (distance <= stopDistance)
        {
            currentPoint = currentPoint + 1;

            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }

        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;

        batRB.AddForce(direction * flySpeed);
    }

    void FixedUpdate()
    {
        batRB.velocity = Vector2.ClampMagnitude(batRB.velocity, maxVelocity);

        if (canThrowTrash)
        {
            num = rnd.Next(1, 3);

            if (num == 1)
            {
                GameObject NewCan = Instantiate(Can, shootPosition.position, Quaternion.identity);
                Can.tag = "Default";
			    NewCan.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * Time.fixedDeltaTime, 0f);
			    NewCan.transform.localScale = new Vector2(NewCan.transform.localScale.x, NewCan.transform.localScale.y);
            }
            else if (num == 2)
            {
                GameObject NewBanana = Instantiate(BananaPeel, shootPosition.position, Quaternion.identity);
                BananaPeel.tag = "Default";
			    NewBanana.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * Time.fixedDeltaTime, 0f);
			    NewBanana.transform.localScale = new Vector2(NewBanana.transform.localScale.x, NewBanana.transform.localScale.y);
            }
            else if (num == 3)
            {
                GameObject NewApple = Instantiate(AppleCore, shootPosition.position, Quaternion.identity);
                AppleCore.tag = "Default";
			    NewApple.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * Time.fixedDeltaTime, 0f);
			    NewApple.transform.localScale = new Vector2(NewApple.transform.localScale.x, NewApple.transform.localScale.y);
            }

            StartCoroutine(BatCooldown());
        }
    }

    private IEnumerator BatCooldown()
    {
        canThrowTrash = false;

        yield return new WaitForSeconds(2.0f);

        canThrowTrash = true;
    }
}
