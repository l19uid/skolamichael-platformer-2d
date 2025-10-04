using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactTag = "Player";
    public KeyCode interactKey = KeyCode.F;
    [Tooltip("If true, interaction requires pressing the 'F' key. If false, interaction happens automatically on trigger enter. /" +
             "Jestliže je true, interakce vyžaduje stisknutí klávesy 'F'. Pokud je false, interakce probíhá automaticky při vstupu do triggeru.")]
    public bool inputInteraction = false;
    [Tooltip("Text, který se zobrazí, pokud musí hráč stisknout klávesu Interakce, pokud je prázdný, zobrazí se Press F")]
    public string hintText;

    
    public  void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            Debug.Log($"Player entered the interactable area of {gameObject}");
            Interact(other);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag))
        {
            if (Input.GetKeyDown(interactKey))
            {
                Interact(other);
            }
         
           Interface.Instance.ShowHint($"Press {interactKey.ToString()} {hintText}");
            
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(interactTag))
        {
            Interface.Instance.HideHint();

            StopInteraction(other);
        }
    }

    public virtual void Interact(Collider2D other)
    {
        Debug.Log($"Player interacted with  {gameObject}");
        Interface.Instance.HideHint();
    }

    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stoped interaction with {gameObject}");
    }

    public void OnDestroy()
    {
        Interface.Instance.HideHint();
    }
}
