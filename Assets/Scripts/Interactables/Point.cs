using UnityEngine;

public class Point : Interactable
{
    public int score = 10;

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.AddScore(score);
        Destroy(gameObject);
    }
    
}
