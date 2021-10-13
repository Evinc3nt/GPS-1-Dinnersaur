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
        //ADD IF GREENS > 0 HERE
        //ADD GREENS - 1 HERE
        lifeSystem.lifePts = lifeSystem.lifePts + 15;
    }

    public void ConsumeMeat()
    {
        //ADD IF MEAT > 0 HERE
        //ADD MEAT - 1 HERE
        lifeSystem.lifePts = lifeSystem.lifePts + 30;
    }

}

