using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public GameObject meat;
    public void killDino()
    {
        Instantiate(meat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
