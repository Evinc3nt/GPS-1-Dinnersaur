using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopulationSystem : MonoBehaviour
{
    public GameObject humanEnd, dinoEnd;

    const int populationLimit = 3;
    public void setPopulation()
    {
        int excessGreen, excessMeat, excessHuman;

        if (PlayerPrefs.GetInt("Meat") >= PlayerPrefs.GetInt("Human") &&  PlayerPrefs.GetInt("Green") >= PlayerPrefs.GetInt("Human"))
        {

            if ( PlayerPrefs.GetInt("Green") < PlayerPrefs.GetInt("Meat"))
            {
                PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - PlayerPrefs.GetInt("Human"));
                Debug.Log("Meat left after subsract to villagers: " + PlayerPrefs.GetInt("Meat"));

                excessGreen =  PlayerPrefs.GetInt("Green") - PlayerPrefs.GetInt("Human");
                PlayerPrefs.SetInt("Human", PlayerPrefs.GetInt("Human") + excessGreen);
                Debug.Log("Human population: " + PlayerPrefs.GetInt("Human"));

                PlayerPrefs.SetInt("Meat", excessGreen);
                Debug.Log("Green left after subsract to villagers: " + excessGreen);

            }
            else
            {
                PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - PlayerPrefs.GetInt("Human"));
                Debug.Log("Green left after subsract to villagers: " + PlayerPrefs.GetInt("Green"));

                excessMeat = PlayerPrefs.GetInt("Meat") - PlayerPrefs.GetInt("Human");
                PlayerPrefs.SetInt("Human", PlayerPrefs.GetInt("Human") + excessMeat);
                Debug.Log("Human population: " + PlayerPrefs.GetInt("Human"));

                PlayerPrefs.SetInt("Meat", excessMeat);
                Debug.Log("Meat left after subsract to villagers: " + excessMeat);

            }
        }
        else if ( PlayerPrefs.GetInt("Green") < PlayerPrefs.GetInt("Human") || PlayerPrefs.GetInt("Meat") < PlayerPrefs.GetInt("Human"))
        {
            if ( PlayerPrefs.GetInt("Green") < PlayerPrefs.GetInt("Meat"))
            {
                PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - PlayerPrefs.GetInt("Human"));
                Debug.Log("Meat left after subsract to villagers: " + PlayerPrefs.GetInt("Meat"));

                excessHuman = PlayerPrefs.GetInt("Human") -  PlayerPrefs.GetInt("Green");
                PlayerPrefs.SetInt("Human", PlayerPrefs.GetInt("Human") - excessHuman);
                Debug.Log("Human left: " + PlayerPrefs.GetInt("Human"));

                PlayerPrefs.SetInt("Green", 0);
                Debug.Log("Green left after subsract to villagers: " + PlayerPrefs.GetInt("Green"));

            }
            else
            {

                PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - PlayerPrefs.GetInt("Human"));
                Debug.Log("Green left after subsract to villagers: " + PlayerPrefs.GetInt("Green"));

                excessHuman = PlayerPrefs.GetInt("Human") - PlayerPrefs.GetInt("Meat");
                PlayerPrefs.SetInt("Human", PlayerPrefs.GetInt("Human") - excessHuman);
                Debug.Log("Human left: " + PlayerPrefs.GetInt("Human"));

                PlayerPrefs.SetInt("Meat", 0);
                Debug.Log("Meat left after subsract to villagers: " + PlayerPrefs.GetInt("Meat"));

            }
        }

        if (PlayerPrefs.GetInt("Green") < 0)
        {
            PlayerPrefs.SetInt("Green", 0);
        }
        if (PlayerPrefs.GetInt("Meat") < 0)
        {
            PlayerPrefs.SetInt("Meat", 0);

        }


        if (PlayerPrefs.GetInt("Human") < populationLimit)
        {
            Time.timeScale = 1f;
            humanEnd.SetActive(true);
            Debug.Log("You lose. Population too unbalance. Dino less than 10");
        }
        else if (PlayerPrefs.GetInt("Dino") < populationLimit)
        {
            Time.timeScale = 1f;
            dinoEnd.SetActive(true);
            Debug.Log("You lose. Population too unbalance. Human less than 10");

        }
        else
        {
            FindObjectOfType<KarmaSystem>().showKarmaBar();
        }
  
    }
}
