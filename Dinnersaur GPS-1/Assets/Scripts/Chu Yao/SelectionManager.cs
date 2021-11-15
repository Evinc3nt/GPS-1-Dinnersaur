using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Animator dialogueAnim,dinoAnim;
    public GameObject dialogueBox, background;

    //Remember put this at the button ON CLICK place
    //so this dialogueBox will disappear, TIME WILL GO
    public void EndDialogue()
    {
        StartCoroutine(WaitAnim());
    }

    IEnumerator WaitAnim()
    {
        Debug.Log("Animation showing");

        yield return new WaitForSecondsRealtime(dinoAnim.GetCurrentAnimatorStateInfo(0).length + dinoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        Debug.Log("Animation Done");

        dialogueBox.SetActive(false);
        background.SetActive(false);
        dialogueAnim.SetBool("IsOpen", false);
        Time.timeScale = 1f;
    }
}
