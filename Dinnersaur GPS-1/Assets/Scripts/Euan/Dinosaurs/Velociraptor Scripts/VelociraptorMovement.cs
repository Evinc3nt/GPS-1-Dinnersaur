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
    
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate() 
    { 
        if (inRange)
        {
            moveVelo(movement);
        }


        else if((transform.position != startPoint) && inRange == false)
        {
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, VeloSpeed * Time.deltaTime);
        }

        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void moveVelo(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * VeloSpeed * Time.deltaTime));
    }
}
