using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorDetection : MonoBehaviour
{
    public VelociraptorMovement vM;

    void OnTriggerEnter2D(Collider2D range)
    {
        if (range.gameObject.tag == "Player")
        {
            Sound.play_sound("brachy");
            vM.inRange = true;
            Debug.Log("Collision!");
        }
    }

    void OnTriggerExit2D(Collider2D range)
    {
        if (range.gameObject.tag == "Player")
        {
            vM.inRange = false;
            Debug.Log("Out of Range!");
        }
    }
}
