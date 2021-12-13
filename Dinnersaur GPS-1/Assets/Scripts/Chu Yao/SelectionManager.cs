using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Animator dialogueAnim,dinoAnim;
    public GameObject dialogueBox, background;

    public GameObject successText, failText, superSuccessText;

    public void EndDialogue()
    {
        StartCoroutine(WaitAnim());
    }

    IEnumerator WaitAnim()
    {

        Debug.Log("Animation Start.");

        yield return new WaitForSecondsRealtime(5f); //playerAnim.GetCurrentAnimatorStateInfo(0).length * playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime

        Debug.Log("Animation Done. Pop up things");

        if (Dino.superSuccess)
        {
            superSuccessText.SetActive(true);
            Dino.superSuccess = false;
        }
        else if (Dino.success || Dino.dinoKilled)
        {
            successText.SetActive(true);
            Dino.success = false;
            Dino.dinoKilled = false;
        }
        if (Dino.fail || Dino.dinoFailKill)
        {
            failText.SetActive(true);
            Dino.fail = false;
            Dino.dinoFailKill = false;
        }

        dialogueBox.SetActive(false);
        background.SetActive(false);
        dialogueAnim.SetBool("IsOpen", false);
    }

}
