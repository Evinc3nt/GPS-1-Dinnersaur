using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvesting : MonoBehaviour
{
    public Player p;
    public static bool anklyoBuff;


    private void Start()
    {
        anklyoBuff = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            Sound.play_sound("harvest");
            if(anklyoBuff)
            {
                p.calculateGreen(2);

            }
            else
            {
                p.calculateGreen(1);
            }
            Destroy(collision.gameObject);
        }

    }
}
