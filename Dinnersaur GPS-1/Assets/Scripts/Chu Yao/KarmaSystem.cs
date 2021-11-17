using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class KarmaSystem : MonoBehaviour
{
    public GameObject balance,moreHuman,moreDino;

    public Slider karmaBar;
    public int maxDino = 25;
    public int maxHuman = 25;
    private int dinoResult, humanResult, balancedResult;


    void Start()
    {

        PlayerPrefs.SetInt("Dino", maxDino);
        PlayerPrefs.SetInt("Human", maxHuman);

        //REMEMBER to remove below when make full game unless it'll reset everyday
        PlayerPrefs.SetInt("MoreDino", 0);
        PlayerPrefs.SetInt("MoreHuman", 0);
        PlayerPrefs.SetInt("Balanced", 0);
    }

    void Update()
    {
        SetKarma(PlayerPrefs.GetInt("Dino"), PlayerPrefs.GetInt("Human"));

        dinoResult = PlayerPrefs.GetInt("MoreDino");
        humanResult = PlayerPrefs.GetInt("MoreHuman");
        balancedResult = PlayerPrefs.GetInt("Balanced");

    }

    public void SetKarma(int dino, int human)
    {

        int karma;
        karma = dino + human;
        karmaBar.maxValue = karma;
        karmaBar.value = human;
    }

    public void KarmaCheck()
    {
        if (karmaBar.value < (karmaBar.maxValue * 0.4))
        {
            PlayerPrefs.SetInt("MoreDino", dinoResult + 1);
            moreDino.SetActive(true);
        }
        else if (karmaBar.value > (karmaBar.maxValue * 0.6))
        {

            PlayerPrefs.SetInt("MoreHuman", humanResult + 1);
            moreHuman.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Balanced", balancedResult + 1);
            balance.SetActive(true);
        }


        Debug.Log("More Dino:Balanced:More Human  =  " + PlayerPrefs.GetInt("MoreDino")  + ":" + PlayerPrefs.GetInt("Balanced") + ":" + PlayerPrefs.GetInt("MoreHuman"));
    }


    public void showKarmaBar()
    {
        FindObjectOfType<PopulationSystem>().setPopulation();//set population first

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        KarmaCheck();
    }

}
