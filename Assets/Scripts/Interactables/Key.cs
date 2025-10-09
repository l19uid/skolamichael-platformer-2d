using System;
using UnityEngine;

public class Key : Interactable
{
    [Tooltip("The door that this key opens. / Dveře, které tento klíč otevírá.")]
    public Door door;

    public void Start()
    {
        if (door == null)
            Debug.LogWarning($"The Key {gameObject} has no door assigned");
    }

    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        door.Unlock();
        Destroy(gameObject);
    }
}
