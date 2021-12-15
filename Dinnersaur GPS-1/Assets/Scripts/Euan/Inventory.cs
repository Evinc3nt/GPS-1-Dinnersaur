using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    public bool invIsOpen = false;
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
        Sound.play_sound("click");
        inventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        invIsOpen = true;
    }

    public void Resume()
    {
        Sound.play_sound("click");
        inventoryMenu.SetActive(false);
        Time.timeScale = 1f;
        invIsOpen = false;
    }


  public void ConsumeGreens()
    {
        Sound.play_sound("click");
        if (lifeSystem.lifePts < 85 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Green") > 0)
            {
                PlayerPrefs.SetInt("Green", (PlayerPrefs.GetInt("Green") - 1));
            }
            lifeSystem.lifePts = lifeSystem.lifePts + 15;
            Sound.play_sound("mcconsume");
        }

        else if (lifeSystem.lifePts >= 85 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Green") > 0)
            {
                PlayerPrefs.SetInt("Green", (PlayerPrefs.GetInt("Green") - 1));
            }
            lifeSystem.lifePts = 100;
            Sound.play_sound("mcconsume");
        }
    }

    public void ConsumeMeat()
    {
        Sound.play_sound("click");
        if (lifeSystem.lifePts < 70 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Meat") > 0)
            {
                PlayerPrefs.SetInt("Meat", (PlayerPrefs.GetInt("Meat") - 1));
            }

            lifeSystem.lifePts = lifeSystem.lifePts + 30;
            Sound.play_sound("mcconsume");
        }

        else if (lifeSystem.lifePts >= 70 && lifeSystem.lifePts < 100)
        {
            if (PlayerPrefs.GetInt("Meat") > 0)
            {
                PlayerPrefs.SetInt("Meat", (PlayerPrefs.GetInt("Meat") - 1));
            }

            lifeSystem.lifePts = 100;
            Sound.play_sound("mcconsume");
        }
    }
}

