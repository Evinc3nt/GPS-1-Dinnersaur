using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    public static bool invIsOpen = false;
    public LifeSystem lifeSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (invIsOpen)
            {
                Resume();
            }
            else
            {
                openInv();
            }
        }
    }

    public void openInv()
    {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        invIsOpen = true;
    }

    public void Resume()
    {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1f;
        invIsOpen = false;
    }


  public void ConsumeGreens()
    {
        if (lifeSystem.lifePts < 85 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Green") > 0)
            {
                PlayerPrefs.SetInt("Green", (PlayerPrefs.GetInt("Green") - 1));
            }
            lifeSystem.lifePts = lifeSystem.lifePts + 15;
        }

        else if (lifeSystem.lifePts >= 85 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Green") > 0)
            {
                PlayerPrefs.SetInt("Green", (PlayerPrefs.GetInt("Green") - 1));
            }
            lifeSystem.lifePts = 100;
        }
    }

    public void ConsumeMeat()
    {
        if (lifeSystem.lifePts < 70 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Meat") > 0)
            {
                PlayerPrefs.SetInt("Meat", (PlayerPrefs.GetInt("Meat") - 1));
            }

            lifeSystem.lifePts = lifeSystem.lifePts + 30;
        }

        else if (lifeSystem.lifePts >= 70 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Meat") > 0)
            {
                PlayerPrefs.SetInt("Meat", (PlayerPrefs.GetInt("Meat") - 1));
            }

            lifeSystem.lifePts = 100;
        }
    }
}

