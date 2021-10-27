using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoticed : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(KillSelf());
    }

    // Update is called once per frame
    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
