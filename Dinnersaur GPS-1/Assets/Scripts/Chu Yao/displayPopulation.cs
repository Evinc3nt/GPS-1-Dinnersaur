using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPopulation : MonoBehaviour
{
    private int human;

    Text humanPopu;

    // Start is called before the first frame update
    void Start()
    {
        humanPopu = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        human = PlayerPrefs.GetInt("Human");
        humanPopu.text = human.ToString();
    }
}
