using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 0.0f;
    public float timerMax;
    public CaudiBuff cB;

    void Awake()
    {
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
        if (timeLeft >= timerMax)
        {
            CancelInvoke("TimeChange");
            Time.timeScale = 0f;
            FindObjectOfType<KarmaSystem>().showKarmaBar();
        }
    }

}