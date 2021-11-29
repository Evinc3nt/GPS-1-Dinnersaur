using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustMeter : MonoBehaviour
{
    public Image fillImage;
    public int maxValue;

    void Start()
    {
        fillImage.fillAmount = 0f;
    }

    public void SetTrustMeter(int trustPoint)
    {
        float val = ((float)trustPoint / maxValue);
        Debug.Log("Trust point in trust meter: " + val);

        fillImage.fillAmount = val;


    }

}
