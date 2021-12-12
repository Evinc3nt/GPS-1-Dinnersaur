using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoticed : MonoBehaviour
{

    public float killSelfTimer; 
    void Awake()
    {
        StartCoroutine(KillSelf());
    }

    IEnumerator KillSelf()
    {
        //!MISSING SOUND FOR HERE!
        //Sound.play_sound("alert");
        yield return new WaitForSeconds(killSelfTimer);
        Destroy(this.gameObject);
    }
}
