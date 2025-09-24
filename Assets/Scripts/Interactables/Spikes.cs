using UnityEngine;

public class Spikes : Interactable
{
    [Header("Spike Settings")]
    [Tooltip(
        "How much damage the spikes will deal to the player upon contact. / Kolik poškození způsobí hráči při kontaktu s trny.")]
    public float damageAmount = 10f;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            // Hurt player for damageAmount
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            // Hurt player for damageAmount
        }
    }
}
