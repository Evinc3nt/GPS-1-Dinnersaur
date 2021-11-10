using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueText, dialogueBox, background;
    public Animator dialogueAnim;
    public Dialogue dialogueInput;
    public static bool GameIsPaused = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            Debug.Log("Dialogue triggered!");

            dialogueAnim.speed = 1;
            //Display
            dialogueBox.SetActive(true);
            background.SetActive(true);
            dialogueAnim.SetBool("IsOpen", true);


            if (dialogueText != null)
            {
                dialogueText.SetActive(true);

                //Start dialogue
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueInput);
            }
        }
    }

    //trigger by clicking button
    public void TriggerDialogue()
    {
        //Display
        dialogueBox.SetActive(true);
        dialogueText.SetActive(true);
        background.SetActive(true);
        dialogueAnim.SetBool("IsOpen", true);

        //Start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueInput);
    }
}
