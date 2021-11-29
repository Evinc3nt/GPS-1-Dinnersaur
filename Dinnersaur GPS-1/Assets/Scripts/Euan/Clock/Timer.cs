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
            timerMax = 10f;
        }
    }

    float TimeChange()
    {
        return timeLeft = timeLeft + 1.0f;
    }

    void Update()
    {
        if ((timeLeft >= timerMax)&& !timesUp) //I use bool to make it run once only in update()
        {
            CancelInvoke("TimeChange");
            Time.timeScale = 0f;
            FindObjectOfType<PopulationSystem>().setPopulation();
            FindObjectOfType<EndingManager>().countDay();
            timesUp = true;
        }
    }

}