using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public GameObject BackgroundSounds;
    public GameObject BGM;
    public GameObject CombatBGM;
    public PauseMenu pM;
    public Inventory iN;


    void Update()
    {
        if ((pM.GameIsPaused == false) && (iN.invIsOpen == false))
        {
            if (Time.timeScale == 1f)
            {
                BGM.SetActive(true);
                CombatBGM.SetActive(false);
            }

            else
            {
                CombatBGM.SetActive(true);
                BGM.SetActive(false);
            }
        }
    }

}
