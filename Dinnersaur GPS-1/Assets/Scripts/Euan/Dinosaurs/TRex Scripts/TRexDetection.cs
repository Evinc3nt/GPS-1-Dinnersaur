using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexDetection : MonoBehaviour
{
    public TRexMovement tRM;

    void OnTriggerEnter2D(Collider2D range)
    {
        if (range.gameObject.tag == "Player")
        {
            Sound.play_sound("trex");
            tRM.inRange = true;
            Debug.Log("Collision!");
        }
    }

    void OnTriggerExit2D(Collider2D range)
    {
        if (range.gameObject.tag == "Player")
        {
            tRM.inRange = false;
            Debug.Log("Out of Range!");
        }
    }
}
