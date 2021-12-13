using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    harvest
}

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D player;
    public Animator animator;
    public PlayerState currentState;
    AudioSource audioSrc;

    private Vector2 movementDirection;
    bool isMoving = false;

    private void Start()
    { 
        currentState = PlayerState.walk;
        audioSrc = GetComponent<AudioSource>();
    }

    void Update() //gets input every frame
    {

        if (Time.timeScale > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentState == PlayerState.walk)
            {
                StartCoroutine(HarvestDelay());
            }
            else if (currentState == PlayerState.walk)
            {
                InputProcessor();
                Movement();
            }

            if(player.velocity.x == 0 && player.velocity.y == 0)
            {
                isMoving = false;
            }

            else
            {
                isMoving = true;
            }

            if (isMoving)
            {
                if (!audioSrc.isPlaying)
                    audioSrc.Play();
            }

            else
                audioSrc.Stop();
        }
    }

    void FixedUpdate() //updates movement at a FIXED frame
    {
        //Movement();
    }

    void InputProcessor() //TO DO: add the animation variables here!!
    {
        Vector3 move = Vector3.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (move != Vector3.zero)
        {
            animator.SetFloat("Horizontal", move.x);
            animator.SetFloat("Vertical", move.y);
        }

        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
        movementDirection = new Vector3(move.x, move.y).normalized;
    }

    void Movement()
    {
        player.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);
    }

    IEnumerator HarvestDelay()
    {
        player.velocity = new Vector3(0, 0).normalized;
        animator.SetBool("isHarvest", true);
        currentState = PlayerState.harvest;
        yield return null;
        animator.SetBool("isHarvest", false);
        yield return new WaitForSeconds(0.7178683f);
        currentState = PlayerState.walk;
    }

    
}
