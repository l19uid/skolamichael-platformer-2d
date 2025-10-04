using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactTag = "Player";
    public KeyCode interactKey = KeyCode.F;
    [Tooltip("If true, interaction requires pressing the 'F' key. If false, interaction happens automatically on trigger enter. /" +
             "Jestliže je true, interakce vyžaduje stisknutí klávesy 'F'. Pokud je false, interakce probíhá automaticky při vstupu do triggeru.")]
    public bool inputInteraction = false;

    private bool _isInteracting;
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
            Interface.Instance.ShowHint($"Press {interactKey.ToString()}");
            if (Input.GetKeyDown(interactKey))
            {
                Interact(other);

            }
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
        _isInteracting = true;
        Interface.Instance.HideHint();


    }

    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stoped interaction with {gameObject}");
        _isInteracting = false;
    }
}
