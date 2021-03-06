using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 0.0f;
    public float timerMax;
    public CaudiBuff cB;
    private bool timesUp;

    void Awake()
    {
        timesUp = false;
        InvokeRepeating("TimeChange", 0f, 0.5f);
        if (cB.caudiBuffOn)
        {
            timerMax = 180f + cB.maxTimerIncrease;
        }

        else
        {
            timerMax = 180f;
        }
    }

    float TimeChange()
    {
        return timeLeft = timeLeft + 1.0f;
    }

    void Update()
    {
        if ((timeLeft >= timerMax)&& !timesUp)
        {
            CancelInvoke("TimeChange");
            Time.timeScale = 0f;

            if (PlayerPrefs.GetInt("TotalDay") != 0)
            {
                FindObjectOfType<PopulationSystem>().setPopulation();

            }

            timesUp = true;
        }
    }

}