using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueText, dialogueBox, background, dialogueTrigger;

    public Animator animator;

    //I put type as TextMeshProUGUI which more advanced to design the text
    //If use pure text, just change [TextMeshProUGUI] to [Text]
    public TextMeshProUGUI text;
    
    //QUEUE like a LIST that more restricted, called FIFO (first in first out) collection
    private Queue<string> sentences;

    public KeyCode continueButton = KeyCode.Space;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(continueButton))
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        //clear previous sentences 
        sentences.Clear(); 

        //looping through all sentence from dialogue.sentences
        foreach (string sentence in dialogue.sentences)
        {
            //adding in queue
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }



    private void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //get sentence in the queue
        string sentence = sentences.Dequeue();

        StopAllCoroutines();  //stop scroll before it scroll new sentences // for player who start the new sentence before it done scroll

        StartCoroutine(textScroll(sentence));
    }

    IEnumerator textScroll(string sentence)
    {
        //first need to set it to empty string
        text.text = ""; 

        foreach(char letter in sentence.ToCharArray())
        {
            text.text += letter; //append letter to the end of string
            yield return new WaitForSecondsRealtime(0.05f);
        }
       
    }

    void EndDialogue()
    {
        dialogueText.SetActive(false);
        dialogueBox.SetActive(false);
        background.SetActive(false);
        dialogueTrigger.SetActive(false);
        animator.SetBool("IsOpen", false);

    }
}
