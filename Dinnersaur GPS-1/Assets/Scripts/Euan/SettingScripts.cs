using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScripts : MonoBehaviour
{
    public GameObject settingScreen;
    
    public void OpenSettings()
    {
        settingScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        settingScreen.SetActive(false);
    }    
}
