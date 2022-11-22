using UnityEngine;
using System.Collections;
 
public class EnemyMovement : MonoBehaviour 
{
    private GameObject enemy;
    public Rigidbody2D enemyRB;
    public Collider2D enemyCollider;

    public Transform target;
    private GameObject player;
    public Rigidbody2D playerRB;
    public LayerMask enemyBounds;

    private float range;
    public float rangeLimit;
    public float patrolSpeed;
    public float chaseSpeed;

    public bool activePatrol;
    public bool activeChase;
 
    // Use this for initialization
    void Start() 
    {
        activePatrol = true;
        activeChase = false;
    }
     
     // Update is called once per frame
    void Update() 
    {
        range = Vector2.Distance(enemyRB.transform.position, playerRB.transform.position);

        if ((range <= rangeLimit) && (playerRB.transform.position.y < -1.0)) 
        {
            Vector2 velocity = new Vector2((transform.position.x - playerRB.transform.position.x) * chaseSpeed, 
                (transform.position.y - playerRB.transform.position.y) * chaseSpeed);
            
            enemyRB.velocity = -velocity;

            if (!activeChase)
            {
                activeChase = true;
                StartCoroutine(Chase());
            }
        }
        else if (!activeChase)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        if (enemyCollider.IsTouchingLayers(enemyBounds))
        {
            Flip();
        }

        enemyRB.velocity = new Vector2(patrolSpeed, 0.0f);
    }

    public void Flip()
    {
        activePatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        activePatrol = true;
    }

    public IEnumerator Chase()
    {
        yield return new WaitForSeconds(3.0f);

        activeChase = false;
    }
}
