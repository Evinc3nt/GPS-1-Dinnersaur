using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class KarmaSystem : MonoBehaviour
{
    public Slider karmaBar;
    public int maxDino = 25;
    public int maxHuman = 25;
    private bool loadScene;
    public TextMeshProUGUI result;

    private int dinoResult, humanResult, balancedResult;

    public void SetKarma(int dino, int human)
    {
        int karma;
        karma = dino + human;
        karmaBar.maxValue = karma;
        karmaBar.value = human;
    }

    void Start()
    {
        PlayerPrefs.SetInt("Dino", maxDino);
        PlayerPrefs.SetInt("Human", maxHuman);

        //REMEMBER to remove below when make full game unless it'll reset everyday
        PlayerPrefs.SetInt("MoreDino", 0);
        PlayerPrefs.SetInt("MoreHuman", 0);
        PlayerPrefs.SetInt("Balanced", 0);

        result = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        SetKarma(PlayerPrefs.GetInt("Dino"), PlayerPrefs.GetInt("Human"));

        dinoResult = PlayerPrefs.GetInt("MoreDino");
        humanResult = PlayerPrefs.GetInt("MoreHuman");
        balancedResult = PlayerPrefs.GetInt("Balanced");


        if (loadScene)
        {
            if (karmaBar.value < karmaBar.maxValue * 0.4)
            {
                PlayerPrefs.SetInt("MoreDino", dinoResult + 1);
                result.text = dinoResult.ToString() + " : " + balancedResult.ToString() + " : " + humanResult.ToString();

                //Debug.Log("More Dino:More Human:Balanced  =  " + PlayerPrefs.GetInt("MoreDino") + ":" + PlayerPrefs.GetInt("MoreHuman") + ":" + PlayerPrefs.GetInt("Balanced"));
            }
            else if (karmaBar.value > karmaBar.maxValue * 0.6)
            {
                PlayerPrefs.SetInt("MoreHuman", humanResult + 1);
                result.text = dinoResult.ToString() + " : " + balancedResult.ToString() + " : " + humanResult.ToString();

                //Debug.Log("More Dino:More Human:Balanced  =  " + PlayerPrefs.GetInt("MoreDino") + ":" + PlayerPrefs.GetInt("MoreHuman") + ":" + PlayerPrefs.GetInt("Balanced"));

            }
            else if(karmaBar.value == karmaBar.maxValue)
            {
                PlayerPrefs.SetInt("Balanced", balancedResult + 1);
                result.text = dinoResult.ToString() + " : " + balancedResult.ToString() + " : " + humanResult.ToString();

                //Debug.Log("More Dino:More Human:Balanced  =  " + PlayerPrefs.GetInt("MoreDino") + ":" + PlayerPrefs.GetInt("MoreHuman") + ":" + PlayerPrefs.GetInt("Balanced"));
            }

            FindObjectOfType<EndingManager>().loadScene();
            loadScene = false;

            //if (Input.GetKey(KeyCode.Z))
            //{
            //}

        }

    }

    public void showKarmaBar()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        loadScene = true;
    }

}