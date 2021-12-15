using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScripts : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject creditScreen;

    public void OpenSettings()
    {
        settingScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        settingScreen.SetActive(false);
    }    

    public void OpenCredits()
    {
        creditScreen.SetActive(true);
        settingScreen.SetActive(false);
    }

    public void CloseCredits()
    {
        settingScreen.SetActive(true);
        creditScreen.SetActive(false);
    }
}
