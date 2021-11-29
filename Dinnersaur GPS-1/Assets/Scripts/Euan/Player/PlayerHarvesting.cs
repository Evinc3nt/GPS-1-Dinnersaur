using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvesting : MonoBehaviour
{
    public Player p;
    public AudioSource resourceObtain;

    private void Start()
    {
        resourceObtain = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            resourceObtain.Play();
            p.calculateGreen(1);
            Destroy(collision.gameObject);
        }

    }
}
