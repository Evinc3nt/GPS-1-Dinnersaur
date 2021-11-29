using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int meat = 5;
    public int green = 5;
    public AudioSource resource;

    void Start()
    {
        PlayerPrefs.SetInt("Meat", meat);
        PlayerPrefs.SetInt("Green", green);
        resource = GetComponent<AudioSource>();
    }
    public void calculateMeat(int dropMeat)
    {
        meat = PlayerPrefs.GetInt("Meat");
        PlayerPrefs.SetInt("Meat", meat += dropMeat);
        resource.Play();
    }

    public void calculateGreen(int dropGreen)
    {
        green = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("Green", green += dropGreen);
        resource.Play();
    }

}
