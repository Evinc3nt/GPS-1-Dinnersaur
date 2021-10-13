using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGreens : MonoBehaviour
{
    // Start is called before the first frame update
    public int greens; //CHANGE to CHUYAO GREENS
    Text greensNum;

    void Start()
    {
        greensNum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        greensNum.text = "X " + greens.ToString(); //CHANGE to CHUYAO GREENS
    }
}
