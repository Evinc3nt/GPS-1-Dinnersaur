using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSFX : MonoBehaviour
{
    public AudioSource charConsume;
    public AudioSource OnClick;

    public void consumeFood()
    {
        charConsume.Play();
    }

    public void ButtonClick()
    {
        OnClick.Play();
    }
}
