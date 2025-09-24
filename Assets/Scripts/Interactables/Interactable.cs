using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactTag = "Player";
    public KeyCode interactKey = KeyCode.F;
    [Tooltip("If true, interaction requires pressing the 'F' key. If false, interaction happens automatically on trigger enter. /" +
             "Jestliže je true, interakce vyžaduje stisknutí klávesy 'F'. Pokud je false, interakce probíhá automaticky při vstupu do triggeru.")]
    public bool inputInteraction = false;
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            Debug.Log("Player entered the interactable area.");
        }
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Player interacted with the object.");
        }
    }
}
