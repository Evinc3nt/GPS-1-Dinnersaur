using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPopulationPopup : MonoBehaviour
{
    float killSelfTimer = 2f;
    void Awake()
    {
        StartCoroutine(KillSelf());
    }

    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(killSelfTimer);
        Destroy(this.gameObject);
    }
}
