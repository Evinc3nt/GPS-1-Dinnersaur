using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueText, dialogueBox, background;
    public Animator animator;
    public Dialogue dialogueInput;
    
    //trigger by colliding specific area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Display
        dialogueBox.SetActive(true);
        background.SetActive(true);
        animator.SetBool("IsOpen", true);
        gameObject.SetActive(false);

        if(dialogueText != null)
        {
            dialogueText.SetActive(true);

            //Start dialogue
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueInput);

        }
    }

    //trigger by clicking button
    public void TriggerDialogue()
    {
        //Display
        dialogueBox.SetActive(true);
        dialogueText.SetActive(true);
        background.SetActive(true);
        animator.SetBool("IsOpen", true);

        //Start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueInput);
    }
}
