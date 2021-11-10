using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int meat = 5;
    public int green = 5;

    void Start()
    {
        PlayerPrefs.SetInt("Meat", meat);
        PlayerPrefs.SetInt("Green", green);
    }
    public void calculateMeat(int dropMeat)
    {
        meat = PlayerPrefs.GetInt("Meat");
        PlayerPrefs.SetInt("Meat", meat += dropMeat);
    }

    public void calculateGreen(int dropGreen)
    {
        green = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("Green", green += dropGreen);
    }

}
