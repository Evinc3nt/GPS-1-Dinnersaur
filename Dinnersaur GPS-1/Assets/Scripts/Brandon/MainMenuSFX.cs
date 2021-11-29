using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSFX : MonoBehaviour
{
    public AudioSource ButtonClick;

    public void OnClick()
    {
        ButtonClick.Play();
    }
}
