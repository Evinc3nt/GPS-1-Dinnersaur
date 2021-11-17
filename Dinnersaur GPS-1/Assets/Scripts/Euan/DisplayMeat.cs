using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayMeat : MonoBehaviour
{
    // Start is called before the first frame update
    private int meat;
    Text meatNum;
    public bool textMesh;
    TextMeshProUGUI meatNum2;

    void Start()
    {
        if(textMesh)
        {
            meatNum2 = GetComponent<TextMeshProUGUI>();
        }
        else
        {
            meatNum = GetComponent<Text>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        meat = PlayerPrefs.GetInt("Meat");
        if(textMesh)
        {
            meatNum2.text = meat.ToString();
        }
        else
        {
            meatNum.text = "X " + meat.ToString();

        }
    }
}
