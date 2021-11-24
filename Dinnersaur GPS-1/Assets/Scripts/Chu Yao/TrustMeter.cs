using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustMeter : MonoBehaviour
{
    public Image fillImage;
    public int maxValue;
    public static bool setMeter = false;

    void Start()
    {
        fillImage.fillAmount = 0f;
    }

    public void SetTrustMeter(int trustPoint)
    {
        float val = ((float)trustPoint / maxValue);

        fillImage.fillAmount = val;

        //if (setMeter)
        //{
        //    StartCoroutine(FillMeter(trustPoint));

        //}

    }

    //IEnumerator FillMeter(float amount)
    //{
    //    float val = ((float) amount / maxValue);

    //    yield return new WaitForSecondsRealtime(2.5f);

    //    fillImage.fillAmount = val;
    //    setMeter = false;
    //}
}
