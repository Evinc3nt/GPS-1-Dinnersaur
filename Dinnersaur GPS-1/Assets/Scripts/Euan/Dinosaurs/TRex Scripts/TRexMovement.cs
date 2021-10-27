using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexMovement : MonoBehaviour
{
    private float TRexSpeed = 1300f;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 startPoint;
    public bool inRange;

    float interval = 2.5f;
    float time = 0f;
    Vector3 direction;

    public GameObject alert;
    bool idle = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
            if (idle == true)
            {
                Instantiate(alert, startPoint + new Vector3(0f, 3f), Quaternion.identity);
                idle = false;
            }

            time += Time.deltaTime;
            while(time >= interval)
            {
                direction = player.transform.position - transform.position;
                StartCoroutine(TRexMoveDelay(direction));
                time -= interval;
            }
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            time = 0f;
            StopCoroutine(TRexMoveDelay(direction));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 2 * Time.deltaTime);
        }

        else
        {
            time = 0f;
            StopCoroutine(TRexMoveDelay(direction));
            rb.velocity = new Vector3(0, 0, 0);
            idle = true;
        }
    }

    void MoveEnemy(Vector3 direction)
    {
        rb.AddForce(direction.normalized * TRexSpeed);
        StartCoroutine(EnemyDelay());
    }

    IEnumerator TRexMoveDelay(Vector3 direction)
    {
        yield return new WaitForSeconds(1f);
        MoveEnemy(direction);
    }

    IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = new Vector3 (0, 0, 0);
    }
}
