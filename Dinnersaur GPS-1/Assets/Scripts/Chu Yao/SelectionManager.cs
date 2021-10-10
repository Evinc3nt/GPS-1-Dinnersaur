using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Animator animator;
    public GameObject dialogueBox, background;

    //Remember put this at the button ON CLICK place
    //so after click a button this dialogueBox will disappear
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        background.SetActive(false);
        animator.SetBool("IsOpen", false);
    }
}
