using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactTag = "Player";
    public KeyCode interactKey = KeyCode.F;

    [Tooltip("If true, interaction requires pressing the 'F' key. If false, interaction happens automatically on trigger enter.")]
    public bool inputInteraction = false;

    [Tooltip("Text, který se zobrazí, pokud musí hráč stisknout klávesu Interakce, pokud je prázdný, zobrazí se Press F")]
    public string hintText;

    private bool playerInRange = false;
    private Collider2D playerCollider;

    void Update()
    {
        if (inputInteraction && playerInRange && Input.GetKeyDown(interactKey))
        {
            Interact(playerCollider);
        }

        if (inputInteraction && playerInRange)
        {
            Interface.Instance.ShowHint($"Press {interactKey.ToString()} {hintText}");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(interactTag)) return;

        if (!inputInteraction)
        {
            Debug.Log($"Player entered the interactable area of {gameObject}");
            Interact(other);
        }
        else
        {
            playerInRange = true;
            playerCollider = other;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(interactTag)) return;

        playerInRange = false;
        playerCollider = null;

        Interface.Instance.HideHint();
        StopInteraction(other);
    }

    public virtual void Interact(Collider2D other)
    {
        Debug.Log($"Player interacted with {gameObject}");
        Interface.Instance.HideHint();
    }

    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stopped interaction with {gameObject}");
    }

    public void OnDestroy()
    {
        Interface.Instance.HideHint();
    }
}