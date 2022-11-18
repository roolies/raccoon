using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public bool CanJump;
    public bool iswalking;
    public bool Grounded;

    public Animator animator;
    
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if(IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            CanJump = true;
        }
        else
        {
            animator.SetBool("IsJumping", true);
            CanJump = false;
        }
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //CanJump = true;
            //animator.SetBool("IsJumping", true);
        }
    
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            //CanJump = false;
            //animator.SetBool("IsJumping", false);
        }
    }
    
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }
    
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        if (context.performed)
        {
            iswalking = true;
            animator.SetBool("IsWalking", true);
        }
        if (context.canceled)
        {
            iswalking = false;
            animator.SetBool("IsWalking", false);
        }
    }
}
