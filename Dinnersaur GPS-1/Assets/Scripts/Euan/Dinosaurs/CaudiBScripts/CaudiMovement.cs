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
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        //TODO: When collide go into interaction mode
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            if (idle == true && delay == 0)
            {
                Instantiate(alert, startPoint + new Vector3(0f, 1.5f), Quaternion.identity);
                idle = false;
            }
             
            delay += Time.deltaTime;
            if (delay >= 2.0f)
            {
                moveCaudi(movement);
            }
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            delay = 0f;
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, CaudiSpeed * Time.deltaTime);
        }

        else
        {
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

