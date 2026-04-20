using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYER : MonoBehaviour
{
    public PharmacyMechanics pharmacy;
    public string[] grannyDialogue;
    public GameObject granny;

    private bool isGrannyDialogue = false;

    public GameObject dialoguePanel;
    public TMPro.TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordspeed;
    public bool playerIsClose; 


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }


        }

        if (dialogueText.text  == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }


    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            if (!isGrannyDialogue)
            {
                // Switch to granny dialogue
                dialogue = grannyDialogue;
                index = 0;
                isGrannyDialogue = true;

                granny.SetActive(true); //show granny

                dialogueText.text = "";
                StartCoroutine(Typing());

            }
            else
            {

                zeroText();

                if (isGrannyDialogue)
                {
                    granny.SetActive(false); // Hide granny here
                }

                pharmacy.DialogueEnded();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
