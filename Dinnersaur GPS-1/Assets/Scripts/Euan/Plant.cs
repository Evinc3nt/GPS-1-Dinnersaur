using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillSelf();
        }
    }
    public void KillSelf()
    {
        Destroy(this.gameObject);
        //Green + 1 over here
    }
}

