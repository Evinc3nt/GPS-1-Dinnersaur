using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Animator dialogueAnim,dinoAnim,playerAnim;
    public GameObject dialogueBox, background,dino;

    public GameObject successText, failText, superSuccessText;

    public void EndDialogue()
    {
        StartCoroutine(WaitAnim());
    }

    IEnumerator WaitAnim()
    {
        yield return new WaitForSecondsRealtime(playerAnim.GetCurrentAnimatorStateInfo(0).length * playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        

        if (Dino.dinoFailKill)
        {
            Debug.Log("Player Animation showing");

            dino.SetActive(false);
            if (Dino.veloFail)
            {
                playerAnim.SetTrigger("FailVelo");
                Dino.veloFail = false;
            }
            if (Dino.caudiFail)
            {
                playerAnim.SetTrigger("FailCaudi");
                Dino.caudiFail = false;
            }
            if (Dino.anklyoFail)
            {
                playerAnim.SetTrigger("FailAnklyo");
                Dino.anklyoFail = false;
            }
            if (Dino.brachyFail)
            {
                playerAnim.SetTrigger("FailBrachy");
                Dino.brachyFail = false;
            }
            if (Dino.tRexFail)
            {
                playerAnim.SetTrigger("FailTRex");
                Dino.tRexFail = false;
            }

            yield return new WaitForSecondsRealtime(playerAnim.GetCurrentAnimatorStateInfo(0).length * playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Dino.dinoFailKill = false;
        }
        else
        {

            Debug.Log("Dino Animation showing");
            //Taming
            if (Dino.success)
            {
                dinoAnim.SetTrigger("Success");

            }
            if (Dino.fail)
            {
                dinoAnim.SetTrigger("Fail");

            }

            //Kill
            if (Dino.dinoKilled || Dino.superSuccess)
            {
                dinoAnim.SetTrigger("Death");
            }


            yield return new WaitForSecondsRealtime(dinoAnim.GetCurrentAnimatorStateInfo(0).length * dinoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);

            Debug.Log("Animation Done. Pop up things");

            if (Dino.success || Dino.dinoKilled)
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
            if (Dino.superSuccess)
            {
                superSuccessText.SetActive(true);
                Dino.superSuccess = false;
            }


        }

        dialogueBox.SetActive(false);
        background.SetActive(false);
        dialogueAnim.SetBool("IsOpen", false);
        Time.timeScale = 1f;
    }
}
