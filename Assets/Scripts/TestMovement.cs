using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
   public float moveSpeed = 1f;
   public Vector2 moveInput = Vector2.zero;
   Rigidbody2D rb;
   
   
   
   private AudioSource audioSource;
   
   void Awake()
   {
       //audioSource = GetComponent<AudioSource>();
       rb = GetComponent<Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezeRotation;
   }
   
   void FixedUpdate()
   {
       rb.velocity = moveInput * moveSpeed;
   }
   
   void OnMove(InputValue value)
   {
       moveInput = value.Get<Vector2>();
   }
}
