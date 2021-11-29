using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public Player currentHitPlayer;
    public int dropMeat = 5;
    public AudioClip playerPickUp;


    public void Start()
    {
        //
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(playerPickUp, transform.position);
            currentHitPlayer = collision.gameObject.GetComponent<Player>();
            currentHitPlayer.calculateMeat(dropMeat);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if(other.gameObject.tag == "Player")
    //        AudioSource.PlayClipAtPoint(playerPickUp, transform.position);
    //}

}
