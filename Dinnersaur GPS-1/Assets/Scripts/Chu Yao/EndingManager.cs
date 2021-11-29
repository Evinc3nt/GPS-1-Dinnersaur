using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class EndingManager : MonoBehaviour
{
    public static int totalDay = 7;
    private int dayCount = 0;
    private int nextDayCount = 1;

    private int moreDino, moreHuman, balanced;
    //private int nextScene;
    public GameObject endingBox;
    public TextMeshProUGUI ending,dayEnd,nextDay;
    public Text dead, pause;


    // Start is called before the first frame update
    void Start()
    {
        //nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        dead.text = dayCount.ToString();
        pause.text = dayCount.ToString();
        dayEnd.text = dayCount.ToString();
        nextDay.text = nextDayCount.ToString();
    }

    public void countDay()
    {
        --totalDay;
        ++dayCount;
        ++nextDayCount;

        //Debug.Log("Day left: " + totalDay);
        //Debug.Log("Day count: " + dayCount);
        if (totalDay == 0)
        {
            setEnding();
        }

    }

    public void setEnding()
    {
        moreDino = PlayerPrefs.GetInt("MoreDino");
        moreHuman = PlayerPrefs.GetInt("MoreHuman");
        balanced = PlayerPrefs.GetInt("Balanced");

        endingBox.SetActive(true);

        if ((moreDino != 0) && (moreHuman != 0))
        {
            if ((moreDino == moreHuman) || ((balanced > moreDino) && (balanced > moreHuman)))
            {
                ending.text = "Balanced End";


            }
        }
        else if ((moreDino > moreHuman) && (moreDino > balanced))
        {

            ending.text = "More Dino End";

        }
        else if ((moreHuman > moreDino) && (moreHuman > balanced))
        {
            ending.text = "More Human End";

        }

    }

}
