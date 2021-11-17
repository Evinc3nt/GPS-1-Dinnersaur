using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class EndingManager : MonoBehaviour
{
    public int day = 7;

    private int moreDino, moreHuman, balanced;
    //private int nextScene;
    public GameObject endingBox;
    public TextMeshProUGUI ending;


    // Start is called before the first frame update
    void Start()
    {
        //nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void loadScene()
    {
        moreDino = PlayerPrefs.GetInt("MoreDino");
        moreHuman = PlayerPrefs.GetInt("MoreHuman");
        balanced = PlayerPrefs.GetInt("Balanced");


        if (day == 0)
        {
            endingBox.SetActive(true);

            if ((moreDino != 0) && (moreHuman != 0) )
            {
                if((moreDino == moreHuman) || ((balanced > moreDino) && (balanced > moreHuman)))
                {
                    ending.text = "Balanced End";

                    Debug.Log("Balanced End");

                }
            }
            else if ((moreDino > moreHuman) && (moreDino > balanced))
            {

                ending.text = "More Dino End";

                Debug.Log("More Dino End");
            }
            else if ((moreHuman > moreDino) && (moreHuman > balanced))
            {
                ending.text = "More Human End";

                Debug.Log("More Human End");
            }
        }
        else
        {
            SceneManager.LoadScene("MapDesign");
            --day;
            Debug.Log("Day left: " + (day+1));
        }
    }
}
