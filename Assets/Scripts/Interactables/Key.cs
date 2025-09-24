using UnityEngine;

public class Key : Interactable
{
    [Tooltip("The door that this key opens. / Dveře, které tento klíč otevírá.")]
    public Door door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            door.Unlock();
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            door.Unlock();
        }
    }
}
