using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexMovement : MonoBehaviour
{
    private float TRexSpeed = 1300f;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 startPoint;
    public bool inRange = false;
    public AudioSource alertNoise;
    public AudioSource trexNoise;
    public AudioSource stompingSound;

    float interval = 2.5f;
    float time = 0f;
    Vector3 direction;

    public GameObject alert;
    bool idle = true;

    public Animator animator;

    void Start()
    {
        stompingSound = GetComponent<AudioSource>();
        alertNoise = GetComponent<AudioSource>();
        trexNoise = GetComponent<AudioSource>();
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
            animator.SetBool("isAlert", true);
            if (idle == true)
            {
                alertNoise.Play();
                Instantiate(alert, startPoint + new Vector3(0f, 2f), Quaternion.identity);
                idle = false;
            }

            time += Time.deltaTime;
            while (time >= interval)
            {
                direction = player.transform.position - transform.position;
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                StartCoroutine(TRexMoveDelay(direction));
                time -= interval;
            }
        }

        else if ((transform.position != startPoint) && inRange == false)
        {
            direction = startPoint;
            animator.Play("Charging");
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetBool("isAlert", false);
            animator.SetFloat("Speed", 1f);
            time = 0f;
            StopCoroutine(TRexMoveDelay(direction));
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 4 * Time.deltaTime);
        }

        else
        {
            animator.Play("Idling");
            animator.SetFloat("Speed", 0f);
            direction = new Vector3(0, 0, 0);
            animator.SetBool("isAlert", false);
            time = 0f;
            StopCoroutine(TRexMoveDelay(direction));
            rb.velocity = new Vector3(0, 0, 0);
            idle = true;
            //stompingSound.Stop();
        }
    }

    void MoveEnemy(Vector3 direction)
    {
        rb.AddForce(direction.normalized * TRexSpeed);
        StartCoroutine(EnemyDelay());
        animator.SetFloat("Speed", 0f);
    }

    IEnumerator TRexMoveDelay(Vector3 direction)
    {
        animator.SetFloat("Speed", 1f);
        yield return new WaitForSeconds(1f);
        MoveEnemy(direction);
    }

    IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = new Vector3 (0, 0, 0);
    }
}
