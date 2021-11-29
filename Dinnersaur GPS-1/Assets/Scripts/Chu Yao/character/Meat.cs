using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public Player currentHitPlayer;
    public int dropMeat = 5;
    public AudioSource playerPickUp;


    public void Start()
    {
        playerPickUp = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // AudioSource.PlayClipAtPoint(playerPickUp, transform.position);
            playerPickUp.Play();
            currentHitPlayer = collision.gameObject.GetComponent<Player>();
            currentHitPlayer.calculateMeat(dropMeat);
            Destroy(gameObject, 0.4f);
        }
    }

}
