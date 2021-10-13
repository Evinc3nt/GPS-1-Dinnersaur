using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMeat : MonoBehaviour
{
    // Start is called before the first frame update
    public int meat;
    Text meatNum;

    void Start()
    {
        meatNum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        meatNum.text = "X " + meat.ToString();
    }
}
