using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D player;
    public Animator animator;


    private Vector2 movementDirection;

    
    void Update() //gets input every frame
    {
        if (Time.timeScale > 0f)
        InputProcessor();
    }

    void FixedUpdate() //updates movement at a FIXED frame
    {
        Movement();
    }

    void InputProcessor() //TO DO: add the animation variables here!!
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        movementDirection = new Vector2(moveX, moveY).normalized;
    }

    void Movement()
    {
        player.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);
    }

}
