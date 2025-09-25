using UnityEngine;

public class Point : Interactable
{
    public int score = 10;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            other.GetComponent<Player>()?.AddScore(score);
            Destroy(gameObject);
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            other.GetComponent<Player>()?.AddScore(score);
            Destroy(gameObject);
        }
    }
}
