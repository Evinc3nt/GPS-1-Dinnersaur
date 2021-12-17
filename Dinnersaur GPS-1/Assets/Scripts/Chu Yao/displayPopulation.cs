using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayPopulation : MonoBehaviour
{
    TextMeshProUGUI humanPopu;

    // Start is called before the first frame update
    void Start()
    {
        humanPopu = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        humanPopu.text = PlayerPrefs.GetInt("Human").ToString();
    }
}
