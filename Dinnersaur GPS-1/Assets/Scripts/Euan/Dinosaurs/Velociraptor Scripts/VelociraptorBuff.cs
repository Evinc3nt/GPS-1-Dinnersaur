using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelociraptorBuff : MonoBehaviour
{
    // Increases player's movespeed by a set amount for a single day
    public float speedBuff = 10.0f;
    public bool veloBuffOn = false;
    private float originalSpeed;

    public PlayerMovement p; //to get the players speed to change it 

    void Start()
    {
        originalSpeed = p.moveSpeed;
    }
    void Update()
    {
        if (veloBuffOn)
        {
            p.moveSpeed = originalSpeed + speedBuff;
            Debug.Log("Move Speed: " + p.moveSpeed);
            //TODO: Add the animation change here for the buff
        }

        else
        {
            p.moveSpeed = originalSpeed;
        }
    }
}
