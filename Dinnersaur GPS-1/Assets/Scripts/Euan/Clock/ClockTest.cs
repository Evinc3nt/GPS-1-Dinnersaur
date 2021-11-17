using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockTest : MonoBehaviour
{
    public RectTransform hand;
    public Timer tm;
    public CaudiBuff cB;

    public float timeToDegrees; //irrelevant atm but might change based on day length

    float startingTimer = 90f;

    void Start()
    {
        tm = FindObjectOfType<Timer>();
    }
    void Awake()
    {
        if (cB.caudiBuffOn)
        {
            timeToDegrees = 180f / 210f;
        }

        else
        {
            timeToDegrees = 180f / 180f;
        }
            
    }

    void FixedUpdate()
    {
        hand.rotation = Quaternion.Euler(0f, 0f, startingTimer - (tm.timeLeft * timeToDegrees));
    }
}
