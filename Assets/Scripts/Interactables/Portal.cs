using System;
using UnityEngine;

public class Portal : Interactable
{
    [Header("Portal Settings")]
    [Tooltip("The location where the player will be teleported to when interacting with the portal. / Pozice, kam bude hráč teleportován po interakci s portálem.")]
    public Vector2 teleportLocation = Vector2.zero;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            other.transform.position = teleportLocation;
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            other.transform.position = teleportLocation;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(teleportLocation, 0.3f);
    }
}
