using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaudiMovement : MonoBehaviour
{
    public float CaudiSpeed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Vector3 startPoint;
    public bool inRange;
    float delay = 0f;
    bool idle = true;
    public Animator animator;
    Vector3 direction;

    public GameObject alert;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        inRange = false;
        startPoint = this.transform.position;
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        direction.Normalize();
        movement = direction;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        //TODO: When collide go into interaction mode
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            direction = player.position - transform.position;
            if (idle == true && delay == 0)
            {
                animator.SetBool("isAlert", true);
                Instantiate(alert, startPoint + new Vector3(0f, 1.5f), Quaternion.identity);
                idle = false;
            }
             
            delay += Time.deltaTime;
            if (delay >= 2.0f)
            {
                animator.SetBool("isChasing", true);
                moveCaudi(movement);
            }
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            direction = startPoint;
            animator.SetBool("isAlert", false);
            delay = 0f;
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, CaudiSpeed * Time.deltaTime);
        }

        else
        {
            animator.SetBool("isAlert", false);
            animator.SetBool("isChasing", false);
            idle = true;
            delay = 0f;
            rb.velocity = new Vector3(0, 0, 0);
        }


    }

    void moveCaudi(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * CaudiSpeed * Time.deltaTime));
    }

}

