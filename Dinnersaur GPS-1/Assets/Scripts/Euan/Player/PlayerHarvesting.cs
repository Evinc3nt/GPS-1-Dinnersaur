using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvesting : MonoBehaviour
{
    public Player p;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            Sound.play_sound("harvest");
            p.calculateGreen(1);
            Destroy(collision.gameObject);
        }

    }
}
