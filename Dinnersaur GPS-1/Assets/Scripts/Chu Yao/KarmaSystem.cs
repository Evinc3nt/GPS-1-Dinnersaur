using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KarmaSystem : MonoBehaviour
{
    public GameObject balance,moreHuman,moreDino;

    public Slider karmaBar;
    public int maxDino = 25;
    public int maxHuman = 25;

    private bool isMoreDino, isMoreHuman, isBalanced;

    void Start()
    {
        isMoreDino = isMoreHuman = isBalanced = false;
        PlayerPrefs.SetInt("Dino", maxDino);
        PlayerPrefs.SetInt("Human", maxHuman);
    }

    public void SetKarma()
    {
        int karma = PlayerPrefs.GetInt("Dino") + PlayerPrefs.GetInt("Human");
        karmaBar.maxValue = karma;
        karmaBar.value = PlayerPrefs.GetInt("Human");

        
        if (PlayerPrefs.GetInt("Human") < Mathf.RoundToInt(karma * 40/100))
        {
            isMoreDino = true;
        }
        else if (PlayerPrefs.GetInt("Human") > Mathf.RoundToInt(karma *60/100))
        {
            isMoreHuman = true;
        }
        else
        {
            isBalanced = true;
        }

        //Debug.Log("KarmaBar.value || karmaBar.maxValue" + PlayerPrefs.GetInt("Human") + " || " + karma);
        //Debug.Log("Karma * 0.4: " + Mathf.RoundToInt(karma * 40 / 100));
        //Debug.Log("Karma * 0.6: " + Mathf.RoundToInt(karma * 60 / 100));

    }

    public void KarmaCheck()
    {

        if (isMoreDino)
        {
            PlayerPrefs.SetInt("MoreDino", PlayerPrefs.GetInt("MoreDino") + 1);
            moreDino.SetActive(true);
        }
        else if (isMoreHuman)
        {

            PlayerPrefs.SetInt("MoreHuman", PlayerPrefs.GetInt("MoreHuman") + 1);
            moreHuman.SetActive(true);
        }
        else if(isBalanced)
        {
            PlayerPrefs.SetInt("Balanced", PlayerPrefs.GetInt("Balanced") + 1);
            balance.SetActive(true);
        }


        Debug.Log("More Dino:Balanced:More Human  =  " + PlayerPrefs.GetInt("MoreDino")  + ":" + PlayerPrefs.GetInt("Balanced") + ":" + PlayerPrefs.GetInt("MoreHuman"));
    }


    public void showKarmaBar()
    {
        SetKarma();

        KarmaCheck();

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }

}
