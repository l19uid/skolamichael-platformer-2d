using UnityEngine;

public class Spikes : Interactable
{
    [Header("Spike Settings")]
    [Tooltip(
        "How much damage the spikes will deal to the player upon contact. / Kolik poškození způsobí hráči při kontaktu s trny.")]
    public float damageAmount = 10f;

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.TakeDamage(damageAmount);

    }

    
}
