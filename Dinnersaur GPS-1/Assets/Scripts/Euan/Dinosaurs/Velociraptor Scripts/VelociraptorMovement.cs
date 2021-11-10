using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorMovement : MonoBehaviour
{
    public float VeloSpeed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Vector3 startPoint;
    public bool inRange;
    bool idle = true;
    float delay = 0f;

    public Animator animator;

    public GameObject alert;

    Vector3 direction;

    //TODO: When collide go into interaction mode
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startPoint = this.transform.position;
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //Vector3 direction = player.position - transform.position;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate() 
    { 
        if (inRange)
        {
            direction = player.position - transform.position;
            if (idle == true && delay == 0)
            {
                Instantiate(alert, startPoint + new Vector3(0f, 1.5f), Quaternion.identity);
                idle = false;
            }

            delay += Time.deltaTime;
            if (delay >= 2.0f)
            {
                moveVelo(movement);
                animator.SetFloat("Speed", 1);
            }
        }


        else if((transform.position != startPoint) && inRange == false)
        {
            direction = startPoint;
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, VeloSpeed * Time.deltaTime);
        }

        else
        {
            delay = 0;
            idle = true;
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetFloat("Speed", 0);
        }
    }

    void moveVelo(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * VeloSpeed * Time.deltaTime));
    }
}
