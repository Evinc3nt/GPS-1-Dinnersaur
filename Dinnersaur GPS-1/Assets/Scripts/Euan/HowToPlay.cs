using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
    public bool tutorialOpen = true;

    public void Resume()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorialOpen = false;
    }

    public void OpenTutorial1()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
    }

    public void OpenTutorial2()
    {
        tutorial2.SetActive(true);
        tutorial1.SetActive(false);
        tutorial3.SetActive(false);
    }
    public void OpenTutorial3()
    {
        tutorial3.SetActive(true);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
    }


}
