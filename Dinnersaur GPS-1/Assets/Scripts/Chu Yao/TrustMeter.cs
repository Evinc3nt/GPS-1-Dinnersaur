using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustMeter : MonoBehaviour
{
    public Slider trustMeter;
    public Gradient gradient;
    public Image fill;
    public int maxValue;

    void Start()
    {
        trustMeter.maxValue = maxValue;
        trustMeter.value = 0;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetTrustMeter(int trustPoint)
    {
        trustMeter.value = trustPoint;
        fill.color = gradient.Evaluate(trustMeter.normalizedValue);
    }
}
