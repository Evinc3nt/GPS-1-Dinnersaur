using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexMovement : MonoBehaviour
{
    private float EnemySpeed = 2000f;
    public Transform player;
    public GameObject playerTransform;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Vector3 distance;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("MoveEnemy", 2f, 1.5f);
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //TODO: When collide enter dialogue mode 
    }

    void MoveEnemy()
    {
        var direction = playerTransform.transform.position - transform.position;
        rb.AddForce(direction.normalized * EnemySpeed);
        StartCoroutine(EnemyDelay());
    }
    
    IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = new Vector3 (0, 0, 0);
    }
}
