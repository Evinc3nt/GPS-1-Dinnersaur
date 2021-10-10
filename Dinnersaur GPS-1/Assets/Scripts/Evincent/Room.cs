using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2 camChange;
    public Vector3 player;
    private CameraBehavior cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cam.minPos += camChange;
            cam.maxPos += camChange;
            collision.transform.position += player;

        }
    }
}
