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
    }

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

    // Metoda pro interakci, kterou lze přepsat v podtřídách
    public virtual void Interact(Collider2D other)
    {
        Debug.Log($"Player interacted with {gameObject}");
        Interface.Instance.HideHint();
    }

    // Metoda pro ukončení interakce, kterou lze přepsat v podtřídách
    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stopped interaction with {gameObject}");
    }

    // Když je objekt zničen, schováme hint
    public void OnDestroy()
    {
        Interface.Instance.HideHint();
    }
}