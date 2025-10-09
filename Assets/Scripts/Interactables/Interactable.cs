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
    
    private bool isInsideTrigger = false;
    private Collider2D _other;
    
    // Když něco vstoupí do triggeru
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Pokud není potřeba stisknout klávesu pro interakci, interagujeme hned
        // Ještě kontrolujeme tag
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            Interact(other);
        }

        // Pokud je potřeba stisknout klávesu pro interakci, nastavíme že je hráč v dosahu
        if (inputInteraction && other.CompareTag(interactTag))
        {
            playerInRange = other.CompareTag(interactTag);
            playerCollider = other;
            Interface.Instance.ShowHint($"Press {interactKey.ToString()} {hintText}");
        }
    }

    private bool playerInRange = false;
    private Collider2D playerCollider;

    void Update()
    {
        // If player is in range and input interaction is required
        if (inputInteraction && playerInRange)
        {
            // Check for interaction key press
            if (Input.GetKeyDown(interactKey))
            {
                Interact(playerCollider);
            }
        }
    }
    
    // When something exits the trigger
    public void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the trigger, stop interaction
        if (other.CompareTag(interactTag))
        {
            StopInteraction(other);
            Interface.Instance.HideHint();
            playerInRange = false;
            playerCollider = null;
        }
    }

    // Function for interaction, can be overridden in subclasses
    public virtual void Interact(Collider2D other)
    {
        Debug.Log($"Player interacted with {gameObject}");
        Interface.Instance.HideHint();
    }

    // Function for stopping interaction, can be overridden in subclasses
    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stopped interaction with {gameObject}");
    }

    // When the object is destroyed, hide the hint
    public void OnDestroy()
    {
        Interface.Instance.HideHint();
    }
}