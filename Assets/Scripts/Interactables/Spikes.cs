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
            other.GetComponent<Player>()?.TakeDamage(damageAmount);
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            other.GetComponent<Player>()?.TakeDamage(damageAmount);
        }
    }
}
