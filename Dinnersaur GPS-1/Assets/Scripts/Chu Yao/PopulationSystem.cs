using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationSystem : MonoBehaviour
{
    int human, dino, meat, green;

    void Update()
    {
        human = PlayerPrefs.GetInt("Human");
        dino = PlayerPrefs.GetInt("Dino");
        meat = PlayerPrefs.GetInt("Meat");
        green = PlayerPrefs.GetInt("Green");
    }


    public void setPopulation()
    {
        int excessGreen, excessMeat, excessHuman;

        if (meat >= human && green >= human)
        {

            if (green < meat)
            {
                excessGreen = green - human;
                PlayerPrefs.SetInt("Human", human + excessGreen);
                Debug.Log("Human population: " + human);
                Debug.Log("Green left after subsract to villagers: " + excessGreen);

                PlayerPrefs.SetInt("Meat", meat - human);
                Debug.Log("Meat left after subsract to villagers: " + meat);
            }
            else if (meat < green)
            {
                excessMeat = meat - human;
                PlayerPrefs.SetInt("Human", human + excessMeat);
                Debug.Log("Human population: " + human);
                Debug.Log("Meat left after subsract to villagers: " + excessMeat);

                PlayerPrefs.SetInt("Green", green - human);
                Debug.Log("Green left after subsract to villagers: " + green);
            }

        }
        else if (green < human || meat < human)
        {
            if (green < meat)
            {
                excessHuman = human - green;
                PlayerPrefs.SetInt("Human", human - excessHuman);
                Debug.Log("Human left: " + human);

                PlayerPrefs.SetInt("Meat", meat - human);
                Debug.Log("Meat left after subsract to villagers: " + meat);

                PlayerPrefs.SetInt("Green", 0);
                Debug.Log("Green left after subsract to villagers: " + green);


            }
            else if (meat < green)
            {
                excessHuman = human - meat;
                PlayerPrefs.SetInt("Human", human - excessHuman);
                Debug.Log("Human left: " + human);

                PlayerPrefs.SetInt("Meat", 0);
                Debug.Log("Meat left after subsract to villagers: " + meat);

                PlayerPrefs.SetInt("Green", green - human);
                Debug.Log("Green left after subsract to villagers: " + green);

            }
        }


        if (human < 10 || dino < 10)
        {
            //gameOver
        }
    }
}
