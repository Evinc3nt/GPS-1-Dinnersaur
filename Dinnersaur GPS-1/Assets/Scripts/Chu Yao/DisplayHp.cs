using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHp : MonoBehaviour
{
    public LifeSystem lifeSystem;
    private int health;

    public Text hpText;

    // Update is called once per frame
    void Update()
    {
        health = lifeSystem.lifePts;
        hpText.text = health.ToString();
    }
}
