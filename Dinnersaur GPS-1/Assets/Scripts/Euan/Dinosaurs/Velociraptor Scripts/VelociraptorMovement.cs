using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorMovement : MonoBehaviour
{
    public float VeloSpeed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        //TODO: When collide go into interaction mode
    }

    void FixedUpdate()
    {
        moveVelo(movement);
    }

    void moveVelo(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * VeloSpeed * Time.deltaTime));
    }
}
