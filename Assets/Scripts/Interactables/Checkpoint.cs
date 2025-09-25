using System;
using UnityEngine;

public class Checkpoint : Interactable
{
    [Header("Portal Settings")]
    [Tooltip("The location where the player will be teleported to when interacting with the portal. / Pozice, kam bude hráč teleportován po interakci s portálem.")]
    public Vector2 checkpointPosition = Vector2.zero;
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            other.GetComponent<Player>()?.SetRespawnPoint(checkpointPosition);
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey))
        {
            other.GetComponent<Player>()?.SetRespawnPoint(checkpointPosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkpointPosition, 0.3f);
    }
}
