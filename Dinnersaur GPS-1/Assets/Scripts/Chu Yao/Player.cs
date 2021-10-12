using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int meat = 5;
    public int green = 5;

    public void calculateMeat(int dropMeat)
    {
        meat += dropMeat;
        PlayerPrefs.SetInt("Meat", meat);
        Debug.Log("Meat + " + dropMeat);
        Debug.Log("Meat Counter: "+ meat);
    }

    public void calculateGreen(int dropGreen)
    {
        green += dropGreen;
        PlayerPrefs.SetInt("Green", green);
        Debug.Log("Green + " + green);
        Debug.Log("Green Counter: " + green);
    }

    //public void calculateHealth(int health)
    //{
    //    health 
    //}

}
