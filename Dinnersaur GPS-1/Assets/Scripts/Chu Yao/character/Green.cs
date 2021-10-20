using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public Player currentHitPlayer;
    public int dropGreen = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            currentHitPlayer = collision.gameObject.GetComponent<Player>();
            currentHitPlayer.calculateGreen(dropGreen);
            Destroy(gameObject);
        }*/
    }
}
