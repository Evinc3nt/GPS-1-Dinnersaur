using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lifePts = 100;
    Text lifePoints;

    void Start()
    {
        lifePoints = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifePoints.text = lifePts.ToString();
    }

    //TODO: 
    /*if (lifePoints <= 0)
     * {
     * GAMEOVER
     * }
     */
}
