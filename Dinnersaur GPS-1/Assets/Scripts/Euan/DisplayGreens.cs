using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGreens : MonoBehaviour
{
    // Start is called before the first frame update
    private int greens;
    Text greensNum;

    void Start()
    {
        greensNum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        greens = PlayerPrefs.GetInt("Green");
        greensNum.text = "X " + greens.ToString(); 
    }
}
