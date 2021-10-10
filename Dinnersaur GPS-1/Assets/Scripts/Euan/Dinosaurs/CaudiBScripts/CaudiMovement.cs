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
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        //TODO: When collide go into interaction mode
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            moveCaudi(movement);
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, CaudiSpeed * Time.deltaTime);
        }

        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }


    }

    void moveCaudi(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * CaudiSpeed * Time.deltaTime));
    }

}

