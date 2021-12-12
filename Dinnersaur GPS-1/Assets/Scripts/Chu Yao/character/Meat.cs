using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public Player currentHitPlayer;
    public int dropMeat = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sound.play_sound("resourceobtain");
            currentHitPlayer = collision.gameObject.GetComponent<Player>();
            currentHitPlayer.calculateMeat(dropMeat);
            Destroy(gameObject);
        }
    }

}
