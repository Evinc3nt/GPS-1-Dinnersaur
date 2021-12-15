using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public void calculateMeat(int dropMeat)
    {
       int  meat = PlayerPrefs.GetInt("Meat");
        PlayerPrefs.SetInt("Meat", meat += dropMeat);
    }

    public void calculateGreen(int dropGreen)
    {
        int green = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("Green", green += dropGreen);
    }

}
