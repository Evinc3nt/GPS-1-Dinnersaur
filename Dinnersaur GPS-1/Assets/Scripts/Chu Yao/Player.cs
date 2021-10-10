using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode Up = KeyCode.UpArrow;
    public KeyCode Down = KeyCode.DownArrow;
    public KeyCode Left = KeyCode.LeftArrow;
    public KeyCode Right = KeyCode.RightArrow;

    private int meat = 0;

    public void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        if (Input.GetKey(Up))
        {
            transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime * Speed);
        }
        if (Input.GetKey(Down))
        {
            transform.Translate(new Vector2(0.0f, -1.0f) * Time.deltaTime * Speed);
        }
        if (Input.GetKey(Left))
        {
            transform.Translate(new Vector2(-1.0f, 0.0f) * Time.deltaTime * Speed);
        }
        if (Input.GetKey(Right))
        {
            transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime * Speed);
        }
    }

    public void calculateMeat(int dropMeat)
    {
        meat += dropMeat;
        PlayerPrefs.SetInt("Meat", meat);
        Debug.Log("+ " + dropMeat);
        Debug.Log("Meat Counter: "+ meat);
    }

}
