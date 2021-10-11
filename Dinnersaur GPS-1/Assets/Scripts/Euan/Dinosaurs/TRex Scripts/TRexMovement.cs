using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexMovement : MonoBehaviour
{
    private float TRexSpeed = 1300f;
    public Transform player;
    //public GameObject playerTransform;
    private Rigidbody2D rb;
    //private Vector3 movement;
    //private Vector3 distance;
    private Vector3 startPoint;
    public bool inRange;

    float interval = 2f;
    float time = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //InvokeRepeating("MoveEnemy", 2f, 1.5f);
        startPoint = this.transform.position;
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        if (inRange)
        {
            time += Time.deltaTime;
            while(time >= interval)
            {
                MoveEnemy();
                time -= interval;
            }
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            time = 0f;
            StopCoroutine(TRexMoveDelay());
            //rb.MovePosition(transform.position + (startPoint * CaudiSpeed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 2 * Time.deltaTime);
        }

        else
        {
            time = 0f;
            StopCoroutine(TRexMoveDelay());
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void MoveEnemy()
    {
        var direction = player.transform.position - transform.position;
        rb.AddForce(direction.normalized * TRexSpeed);
        StartCoroutine(EnemyDelay());
    }

    IEnumerator TRexMoveDelay()
    {
        MoveEnemy();
        yield return new WaitForSeconds(2f);
    }

    IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = new Vector3 (0, 0, 0);
    }
}
