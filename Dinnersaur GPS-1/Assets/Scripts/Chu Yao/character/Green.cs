using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public Player currentHitPlayer;
    public int dropGreen = 3;
    public AudioSource playerPickUp;

    private void Start()
    {
        playerPickUp = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPickUp.Play();
            currentHitPlayer = collision.gameObject.GetComponent<Player>();
            currentHitPlayer.calculateGreen(dropGreen);
            Destroy(gameObject,0.4f);
        }
    }
}
