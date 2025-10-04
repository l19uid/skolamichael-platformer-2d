using System;
using TMPro;
using UnityEngine;

public class Dialogue : Interactable
{
    public string dialogueText = "Hello, this is a dialogue.";
    private TextMeshProUGUI dialogueUI;
    private void Start()
    {
        dialogueUI = Interface.Instance.dialogueUI;
    }

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        dialogueUI.text = dialogueText;
    }

    public override void StopInteraction(Collider2D other)
    {
        base.StopInteraction(other);
        dialogueUI.text = "";
    }
}
