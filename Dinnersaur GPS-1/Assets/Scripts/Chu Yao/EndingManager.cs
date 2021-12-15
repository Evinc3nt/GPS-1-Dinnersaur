using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EndingManager : MonoBehaviour
{
    const int TOTAL_DAY = 7;
    private int meat = 5;
    private int green = 5;


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

        PlayerPrefs.SetInt("MoreDino", 0);
        PlayerPrefs.SetInt("MoreHuman", 0);
        PlayerPrefs.SetInt("Balanced", 0);

        PlayerPrefs.SetInt("Meat", meat);
        PlayerPrefs.SetInt("Green", green);

        PlayerPrefs.SetInt("Human", 13);

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
        if ((PlayerPrefs.GetInt("MoreDino") != 0) && (PlayerPrefs.GetInt("MoreHuman") != 0))
        {
            if ((PlayerPrefs.GetInt("MoreDino") == PlayerPrefs.GetInt("MoreHuman")) || ((PlayerPrefs.GetInt("Balanced") > PlayerPrefs.GetInt("MoreDino")) && (PlayerPrefs.GetInt("Balanced") > PlayerPrefs.GetInt("MoreHuman"))))
            {
                balancedEnd.SetActive(true);

            }
        }
        else if ((PlayerPrefs.GetInt("MoreDino") > PlayerPrefs.GetInt("MoreHuman")) && (PlayerPrefs.GetInt("MoreDino") > PlayerPrefs.GetInt("Balanced")))
        {

            dinoEnd.SetActive(true);

        }
        else if ((PlayerPrefs.GetInt("MoreHuman") > PlayerPrefs.GetInt("MoreDino")) && (PlayerPrefs.GetInt("MoreHuman") > PlayerPrefs.GetInt("Balanced")))
        {
            humanEnd.SetActive(true);
        }

    }

}
