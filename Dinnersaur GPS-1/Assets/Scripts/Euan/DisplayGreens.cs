using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGreens : MonoBehaviour
{
    // Start is called before the first frame update
    private int greens;
    public bool textMesh;

    Text greensNum;
    TextMeshProUGUI greenNum2;

    void Start()
    {
        if (textMesh)
        {
            greenNum2 = GetComponent<TextMeshProUGUI>();

        }
        else
        {
            greensNum = GetComponent<Text>();


        }

    }

    // Update is called once per frame
    void Update()
    {
        greens = PlayerPrefs.GetInt("Green");
        if (textMesh)
        {
            greenNum2.text = greens.ToString();
        }
        else
        {
            greensNum.text = "X " + greens.ToString();
        }
    }
}
