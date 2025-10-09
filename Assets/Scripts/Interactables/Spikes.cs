using UnityEngine;

public class Spikes : Interactable
{
    [Header("Spike Settings")]
    [Tooltip(
        "How much damage the spikes will deal to the player upon contact. / Kolik poškození způsobí hráči při kontaktu s trny.")]
    public float damageAmount = 10f;
    [Tooltip(
        "How much the player will get pushed away upon contact. / Jak moc hráče posune když se jich dotkne.")]
    public float pushAmount = .01f;

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.TakeDamage(damageAmount,pushAmount,transform.position);
    }
}
