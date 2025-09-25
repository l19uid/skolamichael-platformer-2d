using System;
using TMPro;
using UnityEngine;

public class Dialogue : Interactable
{
    public string dialogueText = "Hello, this is a dialogue.";
    private TextMeshProUGUI dialogueUI;
    private void Start()
    {
        dialogueUI = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            dialogueUI.text = dialogueText;
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            dialogueUI.text = dialogueText;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(interactTag))
        {
            dialogueUI.text = "";
        }
    }
}
