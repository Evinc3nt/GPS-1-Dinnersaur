using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EndingManager : MonoBehaviour
{
    const int TOTAL_DAY = 7;

    private int moreDino, moreHuman, balanced;
    public GameObject dinoEnd,humanEnd,balancedEnd;
    public TextMeshProUGUI dayEnd,nextDay;
    public Text dead, pause;

    public void SetDay()
    {
        PlayerPrefs.SetInt("TotalDay", TOTAL_DAY);
        PlayerPrefs.SetInt("DayCount", 1);
        PlayerPrefs.SetInt("NextDayCount", 2);

        Debug.Log("TotalDay: " + PlayerPrefs.GetInt("TotalDay", 0));
        Debug.Log("DayCount: " + PlayerPrefs.GetInt("DayCount", 0));
        Debug.Log("NextDayCount: " + PlayerPrefs.GetInt("NextDayCount", 0));


    }

    private void Update()
    {
        if(dayEnd != null)
        {
            dead.text = PlayerPrefs.GetInt("DayCount").ToString();
            pause.text = PlayerPrefs.GetInt("DayCount").ToString();
            dayEnd.text = PlayerPrefs.GetInt("DayCount").ToString();
            nextDay.text = PlayerPrefs.GetInt("NextDayCount").ToString();

        }

        if (PlayerPrefs.GetInt("TotalDay") == 0)
        {
            SetEnding();
        }

    }

    public void CountDay()
    {

        PlayerPrefs.SetInt("TotalDay", PlayerPrefs.GetInt("TotalDay") - 1);
        PlayerPrefs.SetInt("DayCount", PlayerPrefs.GetInt("DayCount") + 1);
        PlayerPrefs.SetInt("NextDayCount", PlayerPrefs.GetInt("NextDayCount") + 1);

        Debug.Log("Day left: " + PlayerPrefs.GetInt("TotalDay"));
        Debug.Log("Day count: " + PlayerPrefs.GetInt("DayCount"));
    }

    public void SetEnding()
    {
        moreDino = PlayerPrefs.GetInt("MoreDino");
        moreHuman = PlayerPrefs.GetInt("MoreHuman");
        balanced = PlayerPrefs.GetInt("Balanced");


        if ((moreDino != 0) && (moreHuman != 0))
        {
            if ((moreDino == moreHuman) || ((balanced > moreDino) && (balanced > moreHuman)))
            {
                balancedEnd.SetActive(true);

            }
        }
        else if ((moreDino > moreHuman) && (moreDino > balanced))
        {

            dinoEnd.SetActive(true);

        }
        else if ((moreHuman > moreDino) && (moreHuman > balanced))
        {
            humanEnd.SetActive(true);
        }

    }

}
