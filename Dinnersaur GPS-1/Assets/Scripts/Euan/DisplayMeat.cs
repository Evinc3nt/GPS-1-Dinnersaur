using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMeat : MonoBehaviour
{
    // Start is called before the first frame update
    private int meat;
    Text meatNum;

    void Start()
    {
        meatNum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        meat = PlayerPrefs.GetInt("Meat");
        meatNum.text = "X " + meat.ToString(); 
    }
}
